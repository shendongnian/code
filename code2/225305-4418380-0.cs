        static void Main(string[] args)
        {
            var tr = new StreamReader(@"C:\new.txt");
            var SplitBy = "----------------------------------------";
            // Skip first 5 lines of the text file?
            foreach (var i in Enumerable.Range(1, 5)) tr.ReadLine();
            var fullLog = tr.ReadToEnd(); 
            
            String[] sections = fullLog.Split(new string[] { SplitBy }, StringSplitOptions.None);
            //String[] lines = sections.Skip(5).ToArray();
            foreach (String r in sections)
            {
                Console.WriteLine(r);
                Console.WriteLine("============================================================");
            }
        }
