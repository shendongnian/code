        static bool ComparePDFs(string file1, string file2)
        {
            if (!File.Exists(file2))
                return false;
            int i;
            string f1 = File.ReadAllText(file1);
            string f2 = File.ReadAllText(file2);
            if (f1.Length != f2.Length)
                return false;
            // Remove PDF ID from file1
            i = f1.LastIndexOf("/ID [<");
            if (i < 0)
                Console.WriteLine("Error: File is not a valid PDF file: " + file1);
            else
                f1 = f1.Substring(0, i) + f1.Substring(i + 75);
            // Remove PDF ID from file2
            i = f2.LastIndexOf("/ID [<");
            if (i < 0)
                Console.WriteLine("Error: File is not a valid PDF file: " + file2);
            else
                f2 = f2.Substring(0, i) + f2.Substring(i + 75);
            return f1 == f2;
        }
