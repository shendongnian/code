<Grid>
    <TextBlock x:Name="TheTextBlock" Text="Sample Text"/>
    <InkCanvas x:Name="TheInkCanvas" />
</Grid>
**Code Behind**
InkAnalyzer inkAnalyzer;
DispatcherTimer recoTimer;
public MainPage()
{
    this.InitializeComponent();
    TheInkCanvas.InkPresenter.InputDeviceTypes =
       Windows.UI.Core.CoreInputDeviceTypes.Mouse |
       Windows.UI.Core.CoreInputDeviceTypes.Pen;
    TheInkCanvas.InkPresenter.StrokesCollected += inkCanvas_StrokesCollected;
    // StrokeStarted is fired when ink input is first detected.
    TheInkCanvas.InkPresenter.StrokeInput.StrokeStarted +=
        inkCanvas_StrokeStarted;
    inkAnalyzer = new InkAnalyzer();
    // Timer to manage dynamic recognition.
    recoTimer = new DispatcherTimer();
    recoTimer.Interval = TimeSpan.FromSeconds(1);
    recoTimer.Tick += recoTimer_TickAsync;
}
private async void recoTimer_TickAsync(object sender, object e)
{
    recoTimer.Stop();
    if (!inkAnalyzer.IsAnalyzing)
    {
        InkAnalysisResult result = await inkAnalyzer.AnalyzeAsync();
        // Have ink strokes on the canvas changed?
        if (result.Status == InkAnalysisStatus.Updated)
        {
            // Find all strokes that are recognized as handwriting and 
            // create a corresponding ink analysis InkWord node.
            var inkwordNodes =
                inkAnalyzer.AnalysisRoot.FindNodes(
                    InkAnalysisNodeKind.InkWord);
            // Iterate through each InkWord node.
            // Display the primary recognized text (for this example, 
            // we ignore alternatives), and then delete the 
            // ink analysis data and recognized strokes.
            foreach (InkAnalysisInkWord node in inkwordNodes)
            {
                string recognizedText = node.RecognizedText;
                // Display the recognition candidates.
                TheTextBlock.Text = recognizedText;
                foreach (var strokeId in node.GetStrokeIds())
                {
                    var stroke =
                        TheInkCanvas.InkPresenter.StrokeContainer.GetStrokeById(strokeId);
                    stroke.Selected = true;
                }
                inkAnalyzer.RemoveDataForStrokes(node.GetStrokeIds());
            }
            TheInkCanvas.InkPresenter.StrokeContainer.DeleteSelected();
        }
    }
    else
    {
        // Ink analyzer is busy. Wait a while and try again.
        recoTimer.Start();
    }
}
private void inkCanvas_StrokeStarted(InkStrokeInput sender, PointerEventArgs args)
{
    recoTimer.Stop();
}
private void inkCanvas_StrokesCollected(InkPresenter sender, InkStrokesCollectedEventArgs args)
{
    recoTimer.Stop();
    foreach (var stroke in args.Strokes)
    {
        inkAnalyzer.AddDataForStroke(stroke);
        inkAnalyzer.SetStrokeDataKind(stroke.Id, InkAnalysisStrokeKind.Writing);
    }
    recoTimer.Start();
}
  [1]: https://docs.microsoft.com/en-us/windows/uwp/design/input/convert-ink-to-text#dynamic-recognition
