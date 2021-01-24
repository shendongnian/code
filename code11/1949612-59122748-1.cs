        FileStream objFS = new FileStream(OpenFile(), FileMode.Open);
        List<string> list = new List<string>();
        using (StreamReader Sr = new StreamReader(FS))
        {
            char c = 'T';
            
                string line = Sr.ReadLine();
            while (line != null)
           {
            
                //MessageBox.Show(line.ToString());
               if (line.Contains(c))
                {
                    list.Add(line);
                   // MessageBox.Show(line.ToString());
                }
               
                line = Sr.ReadLine();
            }
    
            FS.Close();
        }
        return list;
    }
