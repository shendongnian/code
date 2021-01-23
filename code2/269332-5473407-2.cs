    private void button1_Click(object sender, EventArgs e)
    {         
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        Grammar dictationGrammar = new DictationGrammar();
        recognizer.LoadGrammar(dictationGrammar);
        try
        {
            button1.Text = "Speak Now";
            recognizer.SetInputToDefaultAudioDevice();
            RecognitionResult result = recognizer.Recognize();
            button1.Text = result.Text;
        }
        catch (InvalidOperationException exception)
        {
            button1.Text = String.Format("Could not recognize input from default aduio device. Is a microphone or sound card available?\r\n{0} - {1}.", exception.Source, exception.Message);
        }
        finally
        {
            recognizer.UnloadAllGrammars();
        }                          
    }
