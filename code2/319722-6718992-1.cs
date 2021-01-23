    while(true) {
        Thread.Sleep(500); // lets get a break
        if(!System.IO.File.Exists(FILE_NAME)) continue;
        using (System.IO.StreamReader sr = System.IO.File.OpenText(FILE_NAME)) 
        {
            string s = "";
            while ((s = sr.ReadLine()) != null) 
            {
                if(s.Contains(TEXT_TO_SEARCH)) {
                    // output it
                }
            }
        }
    }
