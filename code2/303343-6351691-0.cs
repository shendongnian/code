    const int E_Abort = unchecked((int)0x80004004); 
    EventCode evCode; 
    int gh = mediaEvent.WaitForCompletion(1000, out evCode); 
    DsROTEntry rot = new DsROTEntry(filter); 
    while (gh == E_Abort) 
    { System.Windows.Forms.Application.DoEvents(); 
    gh = this.mediaEvent.WaitForCompletion(1000, out evCode); }  
