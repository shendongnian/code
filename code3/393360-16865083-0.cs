        static string BlastWriteFile(FileInfo file)
        {
            string blasfile = " ";
            using (StreamReader sr = file.OpenText())
            {
                string s = " ";
                while ((s = sr.ReadLine()) != null)
                {
                    blasfile = blasfile + s + "\n";
                    Console.WriteLine();
                }
            }
            return blasfile;
        }
