    void pp_Exited(object sender, EventArgs e){ 
       Dispatcher.BeginInvoke(new Action(delegate {    
          button1.IsEnabled = true;       
       }), System.Windows.Threading.DispatcherPriority.ApplicationIdle, null);
    }
