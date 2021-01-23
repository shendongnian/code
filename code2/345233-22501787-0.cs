     StreamWriter sw =  ....    // using StreamWriter
    // you read the File  ...
    // and now you want to write each line for this big File using WriteLine ();
    
    
    for ( .....)    // this is a big Loop because the File is big and has many Lines
    
    {
    
     sw.WriteLine ( *whatever i read* );  //we write here somrewhere ex. one .txt anywhere
    
     sw.Flush();  // each time the sw.flush() is called, the sw.WriteLine is executed
    
    }
    
    sw.Close();
