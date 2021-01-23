    public class PigLatinClass
    {
        public static string ToPigLatin(string sentence)
        {
            // Convert a string to pig latin
        }
        public static string FromPigLatin(string sentence)
        {
            // Convert a string from pig latin (opposite logic of above)
        }
        public static string PigTalk()
        {
            string sentence;
            Console.WriteLine("Enter a sentence to convert into PigLatin");
            sentence = Console.ReadLine();
            sentence = ToPigLatin(sentence);
            Console.WriteLine(sentence);
            Console.WriteLine("Press Enter to flip the sentence back.");
            Console.ReadKey(true);
            sentence = FromPigLatin(sentence);
            Console.WriteLine(sentence);
        }
    }
