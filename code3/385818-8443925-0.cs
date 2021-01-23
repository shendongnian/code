    static class TestClass {
        static void Main(string[] args) {
            string[] tests = { @"C:\Projects\test\whatever\files\media\10\00\00\80\test.jpg",
            @"C:\Projects\test\whatever\files\media\10\00\00\80\some\foldertest.jpg",
            @"C:\10\00\00\80\test.jpg",
            @"C:\10\00\00\80\test.jpg"};
            foreach (string test in tests) {
                int number = ExtractNumber(test);
                Console.WriteLine(number);
            }
            Console.ReadLine();
        }
        static int ExtractNumber(string path) {
            Match match = Regex.Match(path, @"(([0-9]{2})\\){4}");
            if (!match.Success) {
                throw new Exception("The string does not contain the defined Number");
            }
            //get second group that is where the number is
            Group @group = match.Groups[2];
            //now concat all captures
            StringBuilder builder = new StringBuilder();
            foreach (var capture in @group.Captures) {
                builder.Append(capture);
            }
            //pares it as string and off we go!
            return int.Parse(builder.ToString());
        }
    }
