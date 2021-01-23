    p.Start();
    using (StreamWriter sr= p.StandardInput)
    {
         foreach(var v in lsStatic){
             sr.WriteLine(v);
         }
         sr.Close();
    }
    // Wait for the write to be completed
    p.WaitForExit();
    p.Close();
