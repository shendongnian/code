    bool started = False;
    Process p = new Process();
    p.StartInfo = YourStartInfo;
    started = p.Start();
    try {
      int procId = p.Id;
    }
    catch(InvalidOperationException){
      started = False
    }
    catch(Exception ex) {
      started = False
    }
