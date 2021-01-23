       public class ViewModel       
       {       
        public ObservableCollection<TData> Data { get; set; }       
       
        //static async method that behave like a constructor       
        async public static Task<ViewModel> BuildViewModelAsync()  
        {       
         ObservableCollection<TData> tmpData = await GetDataTask();  
         return new ViewModel(tmpData);
        }       
        // private constructor called by the async method
        private ViewModel(ObservableCollection<TData> Data)
        {
         this.Data=Data;   
        }
       }  
