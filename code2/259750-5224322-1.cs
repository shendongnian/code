    double returnValue = 0;
    
    var b = new BackgroundWorker();
    b.DoWork += new DoWorkEventHandler(
        delegate(object sender, DoWorkEventArgs e) {
            for(int i=0;i<100;i++){
                returnValue += (i+1);
            }
        }
    );
    
    b.RunWorkerAsync();
    while(b.IsBusy){
      Application.DoEvents();
    }
    return returnValue;
