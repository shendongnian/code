    public class MyViewModel
    {
        private IBackgroundWorker _bgworker;
        public MyViewModel(IBackgroundWorker bgworker)
        {
            _bgworker = bgworker;
        }
        private void OnLoadData()    
        {        
            IsBusy = true; // view is bound to IsBusy to show 'loading' message.        
            _bgworker.DoWork += (sender, e) =>        
            {          
                MyData = wcfClient.LoadData();        
            };        
            _bgworker.RunWorkerCompleted += (sender, e) =>        
            {          
                IsBusy = false;        
            };        
            _bgworker.RunWorkerAsync();    
        }
    }
