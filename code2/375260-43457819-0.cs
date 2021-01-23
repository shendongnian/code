     public class MyViewModel
        {
                public MyDataTable Data { get; set; }
                public MyViewModel()
                   {
                       loadData(() => GetData());
                   }
                   private async void loadData(Func<DataTable> load)
                   {
                      try
                      {
                          MyDataTable = await Task.Run(load);
                      }
                      catch (Exception ex)
                      {
                           //log
                      }
                   }
                   private DataTable GetData()
                   {
                        DataTable data;
                        // get data and return
                        return data;
                   }
        }
