    static void Write(string text, string file)
        {
            using (StreamWriter sw = File.AppendText(file))// Creates or opens and appends
            {
                sw.WriteLine(text);
            }
        }
