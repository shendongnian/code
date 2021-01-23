    // given these two methods extracted from your events
    void DoBar()
    {
    
        var file = File.AppendText(@"c:\output.txt");
    
        foreach (string tmpLine in File.ReadAllLines(@"c:\filename.txt"))
        {
            if (File.Exists(tmpLine))
            {
                file.WriteLine(tmpLine);
            }
        }
    
        file.Close();
    
    }
    void DoFoo()
    {
            using (StreamWriter sw = File.AppendText(@"c:\output.txt"))
            {
                StreamReader sr = new StreamReader(@"c:\filename.txt");
    
                string myString = "";
                while (!sr.EndOfStream)
                {
    
                    myString = sr.ReadLine();
                    int index = myString.LastIndexOf(":");
                    if (index > 0)
                        myString = myString.Substring(0, index);
    
                    sw.WriteLine(myString);
                }
            }
    
    }
        // you can subscribe like this
    button1.Click += DoFoo;
    button1.Click += DoBar;
    button2.Click += DoBar;
