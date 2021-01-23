           string mydocpath=Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);     
           StringBuilder sb = new StringBuilder();
            foreach (string txtName in Directory.GetFiles(@"D:\Links","*.txt"))
            {
                using (StreamReader sr = new StreamReader(txtName))
                {
                sb.AppendLine(txtName.ToString());
                sb.AppendLine("= = = = = =");
                sb.Append(sr.ReadToEnd());
                sb.AppendLine();
                sb.AppendLine();   
                }     
            }
            using (StreamWriter outfile=new StreamWriter(mydocpath + @"\AllTxtFiles.txt"))
            {    
            outfile.Write(sb.ToString());
            }   
