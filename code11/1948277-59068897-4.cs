        public static Task<bool> StartSTATask(Action func) {
          var tcs = new TaskCompletionSource<bool>();
          Thread thread = new Thread(() =>
          {
            try {
              func();
              tcs.SetResult(true);
            }
            catch (Exception e) {
              tcs.SetException(e);
            }
          });
          thread.SetApartmentState(ApartmentState.STA);
          thread.Start();
          return tcs.Task;
        }
    
    public CancellationTokenSource cancel_task = new CancellationTokenSource();  
    
    private async void Button1_Click(object sender, RoutedEventArgs e)
    {
                //Doing some work in UI thread before calling Task.Run …
              try{
                await StartSTATask(() => { Export_to_Excel(dict_queries, dtp.Value);});
               }
              catch(Exception ex){
                  MessageBox.Show (ex.Message); //lets keep UI things in UI thread
              }
    
    }
    
    void Export_to_Excel(Dictionary<string, int> queries, DateTime? date)
    {
      
           using (var con = new OracleConnection(conn_string))
           {
             con.Open();
    
             //Fetching DB Command to start with exporting data ...
    
             //Inicializing my .dll method, added as reference to project   
             var export_xlsx = new Excel_export();
    
             export_xlsx.Export_command(cmd_export,cancel_task.Token);
           } 
         }  
     }
    //into dll
    
    public void Export_command(cmd_export,cancel_task.Token){
      //do work
      Application.Current.Dispatcher.Invoke( () => SaveFileDialog.ShowDialog());
    }
