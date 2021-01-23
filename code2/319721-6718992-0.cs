        using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName)) 
        {
            string s = "";
            while ((s = sr.ReadLine()) != null) 
            {
                if(s.contains(TEXT_TO_SEARCH)) {
                    // output it
                }
            }
        }
