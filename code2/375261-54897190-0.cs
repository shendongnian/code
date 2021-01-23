    public class ViewModel
    {
        private Lazy<ObservableCollection<TData>> Data;
        async public ViewModel()
        {
            Data = new Lazy<ObservableCollection<TData>>(GetDataTask);
        }
        public ObservableCollection<TData> GetDataTask()
        {
            Task<ObservableCollection<TData>> task;
            //Create a task which represents getting the data
            return task.GetAwaiter().GetResult();
        }
    }
