    void MyFileHandlingMethod()
    {
       ...
       using (TextReader tr2 = new StreamReader(nfilepath))
       {
         resultN = tr2.ReadLine();         
       } //tr2.Dispose() inserted automatically here        
       ...
    }
