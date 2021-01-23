    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Speech.Recognition;
    namespace speech
    {
    class Program
    {
        static void Main(string[] args)
        {
            SpeechRecognitionEngine mynizer = new SpeechRecognitionEngine();
           
            GrammarBuilder builder = new GrammarBuilder();
            builder.AppendDictation();
            Grammar mygram = new Grammar(builder);
            mynizer.SetInputToDefaultAudioDevice();
            mynizer.LoadGrammar(mygram);
            while (true)
            {
                Console.WriteLine(mynizer.Recognize().Text);
            }
        }
    }
    }
