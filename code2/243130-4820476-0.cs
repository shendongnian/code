    BackgrundworkRunasync(object sender, DoWorkEventArgs e )
    {
         e.Result = GetData();
    }
    
    BackGroundWorkerComplete ( object sender, RunWorkerCompletedEventArgs e )
    {
        CreateControl mycontrol = new CreateControl() //Tyep of WindowsForm
         mycontrol.Data = e.Result; 
       myControl.mdiparent = this;
       myControl.Show();
    }
