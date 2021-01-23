    interface IDialogService
    {
        void ShowRelatedDocumentsA(A a);
    }
...
    class MyViewModel
    {
        private IDialogService _dialogService
        
        public MyViewModel(IDialogService dialogService) { _dialogService = dialogService; }
        public void DoSomething()
        {
            _dialogService.ShowDialog(...);
        }
    }
