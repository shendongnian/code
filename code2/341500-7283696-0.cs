        static void Main(string[] args) {
            string path = @"c:\temp\លួចស្រលាញ់សង្សារគេ.DAT";
            System.IO.File.WriteAllText(path, "hello");
            string txt = System.IO.File.ReadAllText(path);
        }
