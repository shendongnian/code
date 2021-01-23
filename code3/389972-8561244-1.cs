    public interface IDialogService
    {
        void ShowMessageBox(...);
    
        ...
    }
    
    public class SomeClass
    {
        private IDialogService dialogService;
    
        public SomeClass(IDialogService dialogService)
        {
           this.dialogService = dialogService;
        }
    
        public void SomeLogic()
        {
            ...
            if (ok)
            {
                this.dialogService.ShowMessageBox("SUCCESS", ...);
            }
            else
            {
                this.dialogService.ShowMessageBox("SHIT HAPPENS...", ...);
            }
        }
    }
