    try{
     Process myProcess = new Process();
     myProcess.StartInfo.FileName = tmpFileName;
     myProcess.EnableRaisingEvents = true;
     myProcess.Exited += new EventHandler(myProcess_Exited);
     myProcess.Start();
    }
    catch (Exception ex){
     //Handle ERROR
     return;
    }
    // Method Handle Exited event. 
    private void myProcess_Exited(object sender, System.EventArgs e){
     if (File.Exists(tmpFileName))
        {
           File.Delete(tmpFileName);
        }
    }
