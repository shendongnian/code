public partial class Form1 : Form 
{
    private readonly SpeechRecognitionEngine _recognizer = 
        new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
    protected override void Dispose (bool disposing)
    {
        if (disposing)
        {
            _recognizer.Dispose();
        }
        base.Dispose(disposing);
    }
}
