    class Program
    {
        static void Main(string[] args)
        {
            // This is your other class where you set button text to countSAO value
            Console.WriteLine("My Button Text: " + Class1.countSAO.ToString());
        }
    }
    public static class Class1
    {
        // simulate reading lines from file
        public static List<String> SAO_Num = new List<String>() {
            "test1",
            "test2",
            "test3",
            "test4",
            "test5",
            "test6",
            "test7",
            "test8",
            "test9",
            "test10"
        };
        public static int countSAO = SAO_Num?.Count ?? 0;
    }
