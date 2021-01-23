    public IExtDialogFactory ExtDialogFactory { get; set; }
    public interface IExtDialogFactory
    {
        UserControl CreateDialog(); 
    }
