    public class DetailViewModel : IDisposable
    {
        public DetailViewModel(MyDetailModel detailModel)
        {
            // Retain the Detail Model
            this.model = detailModel;
            // Handle changes to the Model not coming from this ViewModel
            if(model != null)
                PropertyChangedEventManager.AddHandler(model, model_PropertyChanged, "");
        }
    
        public void Dispose()
        {
            if(model != null)
                PropertyChangedEventManager.RemoveHandler(model, model_PropertyChanged, "");
        }
    }
