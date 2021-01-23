    // Open this once at the beginning!
    using(fw = new System.IO.StreamWriter(path, true))
    {
        using(StreamReader sr = new StreamReader("c:\\Thunderbird_Inbox.txt"))
        {
            string working;
            string mystring;
            while ((mystring = sr.ReadLine()) != null)
            {
               if (mystring == strBeginMarker)
               {
                    writeLog(mystring);
                    //read the next line
                    working = sr.ReadLine();
                    while( !(working.StartsWith(strEndMarker)))
                    {
                        fw.WriteLine(working);
                        working = sr.ReadLine();
                    }
                }
            }
        }
    }
    this.Text = "DONE!!";
