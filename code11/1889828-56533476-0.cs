    public static void waitforstart() {
            while (true) {
                SpeechRecognitionEngine oEscucha = new SpeechRecognitionEngine();
                oEscucha.SetInputToDefaultAudioDevice();
                GrammarBuilder gr = new GrammarBuilder();
                oEscucha.LoadGrammar(new DictationGrammar());
                oEscucha.SpeechRecognized += Deteccion;
                oEscucha.Recognize();
                Console.WriteLine(intro);
                if (intro.IndexOf("botella", 0, StringComparison.CurrentCultureIgnoreCase) != -1) { //That chechs if "botella" is inside the text ignoring uppercase
                    break;
                }
        } }
