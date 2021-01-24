public partial class Form1 : Form 
{
    private readonly SpeechRecognitionEngine recognizer = 
        new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
    protected override void Dispose (bool disposing)
    {
        if (disposing)
        {
            recognizser.Dispose();
        }
        base.Dispose(disposing);
    }
}
