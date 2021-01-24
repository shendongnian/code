    class Program
    {
        static void Main(string[] args)
        {
            // method 1
            // simulate reading lines from file
            List<String> SAO_Num = new List<String>() {
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
            Class1.countSAO = SAO_Num.Count;
            Console.WriteLine("1) My Button Text: " + Class1.countSAO.ToString());
            // method 2
            Console.WriteLine("2) My Button Text: " + Class1.MyCountSAOValue().ToString());
        }
    }
    public static class Class1
    {
        public static int countSAO;
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
        public static int MyCountSAOValue()
        {
            countSAO = SAO_Num.Count;
            return countSAO;
        }
    }
