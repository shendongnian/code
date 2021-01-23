      public void Main()
        {
            // TODO: Add your code here
            string Line = string.Empty;
            using (StreamReader sr = new StreamReader(@"D:\ssis\queryfile.txt"))//reading the filename
            {
                var text = string.Empty;
                do
                {
                    //     MessageBox.Show(Line);
                    text = Line = sr.ReadToEnd();// storing it in a variable by reading till end
                    MessageBox.Show(Line);
                } while ((Line = sr.ReadLine()) != null);
                
                var text1 = text.Replace("[", string.Empty).Replace("]", string.Empty);//replacing brackets with empty space
                MessageBox.Show(text1);
           
                Regex r = new Regex(@"(?<=from|join)\s+(?<table>\S+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);//regex for extracting the tablename after from and join
                Match m = r.Match(text1);//creating match object
                MessageBox.Show(m.Groups[1].Value);
                var v = string.Empty;
                 
                while (m.Success)
                {
                    v = m.Groups[0].Value;
                    m = m.NextMatch();
                    StreamWriter wr = new StreamWriter(@"D:\ssis\writefile.txt", true);// writing the match to the file
                    var text2 = v.Replace(".", " ,"); // replace the . with , seperated values
                    wr.WriteLine(text2);
                    sr.Close();
                    wr.Close();
                }
            }
        }
