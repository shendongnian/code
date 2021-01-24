var loader = mCont.Data.LoadFromTextFile<Analog>(separatorChar: ',', hasHeader: false);
IDataView data = loader.Load(new MultiFileSource("myYesSignalData.csv", "myNoSignalData.csv"));
However, I currently see no way to let the trainer know which examples are positive and which are negative other than to add a label column to both files: in the "yes" file add an all-ones column and in the "no" file add an all-zeros column. Then define the `Analog` class this way:
public class Analog
{
    [LoadColumn(0, Global.SAMPLE_SIZE - 1)]
    [VectorType(Global.SAMPLE_SIZE)]
    public float[] DiscreteSignal { get; set; }
    [LoadColumn(Global.SAMPLE_SIZE)]
    public float Label { get; set; }
}
Adding the label column can be done with a simple C# program, such as this:
public class AnalogNoLabel
{
    [LoadColumn(0, Global.SAMPLE_SIZE - 1)]
    [VectorType(Global.SAMPLE_SIZE)]
    public float[] DiscreteSignal { get; set; }
}
public void AddLabel(MLContext mCont)
{
    IDataView data = mCont.Data.LoadFromTextFile<AnalogNoLabel>("myYesSignalData.csv", separatorChar: ',', hasHeader: false);
    var pipeline = mCont.Transforms.CustomMapping<AnalogNoLabel, Analog>((input, output) => {
        output.DiscreteSignal = input.DiscreteSignal;
        output.Label = 1;
    }, contractName: null);
    IDataView dataWithLabel = pipeline.Fit(data).Transform(data);
    using (var stream = new FileStream("myNewYesSignalData.txt", FileMode.Create))
        mCont.Data.SaveAsText(dataWithLabel, stream);
}
and a similar script for "myNoSignalData.csv" with `output.Label = 0` instead of `output.Label = 1`.
