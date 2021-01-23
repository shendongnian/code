    using System;
    using System.Collections.Generic; 
    using System.Linq;
    using System.Text;
    using System.Speech.Recognition;
    namespace speectest
    {
    class Program
    {
        static void Main(string[] args)
        {
            SpeechRecognitionEngine engine = new SpeechRecognitionEngine();
            
            GrammarBuilder grandma = new GrammarBuilder();
            engine.SetInputToDefaultAudioDevice();
            grandma.AppendDictation();
            engine.LoadGrammar(new Grammar(grandma));
            engine.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(engine_RecognizeCompleted);
            engine.RecognizeAsync();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
        static void engine_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            Console.WriteLine(e.Result.Text);
        }
    }
    }
