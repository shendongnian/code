class CancerData
{
    [LoadColumn(1, 30), ColumnName("Features")]
    public float[] FeatureVector { get; set; }
    [LoadColumn(0)]
    public string Target { get; set; }
}
// ...
var trainData = mlContext.Data.LoadFromTextFile<CancerData>("Cancer-train.csv", hasHeader: true, separatorChar: ';');
var targetMap = new Dictionary<string, bool> { { "M", true }, { "B", false } };
var pipeline = mlContext.Transforms.Conversion.MapValue("Target", targetMap)
    .Append(mlContext.Transforms.NormalizeMinMax("Features"))
    .AppendCacheCheckpoint(mlContext)
    .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Target", featureColumnName: "Features"));
