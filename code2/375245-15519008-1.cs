     public class ViewModel
        {
            public ObservableCollection<TData> Data { get; set; }
           public ViewModel()
            {              
                new Action(async () =>
                {
                      Data = await GetDataTask();
                }).Invoke();
            }
        
            public Task<ObservableCollection<TData>> GetDataTask()
            {
                Task<ObservableCollection<TData>> task;
                //Create a task which represents getting the data
                return task;
            }
        }
