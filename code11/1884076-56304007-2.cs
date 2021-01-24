            const string path = @"D:\RichTextBox\Example.txt";
            var rtbInfo = richTextBox1.Rtf;
            if (!File.Exists(path))
            {
                File.Create(path);
                TextWriter textWriter = new StreamWriter(path);
                textWriter.WriteLine(rtbInfo);
                textWriter.Close();
            }
            else if (File.Exists(path))
            {
                 File.WriteAllText(path, rtbInfo);
            }
