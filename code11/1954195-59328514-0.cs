    using (MemoryStream ms = new MemoryStream())
    {
        using (var sw = new StreamWriter(ms, new UnicodeEncoding()))
        {
            sw.Write(BAIFile);
            //sw.Flush();  -- you don't need this
            //sw.Close();
    
            //return File(ms.GetBuffer(), "text/plain", DateTime.Now.ToShortDateString() + ".BAI");
        }
        //use this instead
        File(ms.ToArray(), "text/plain", DateTime.Now.ToShortDateString() + ".BAI");
    }
