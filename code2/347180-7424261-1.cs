    public class DetailViewModel : IDisposable
    {
        public DetailViewModel(MyDetailModel detailModel)
        {
            // Retain the Detail Model
            this.model = detailModel;
    
            // Handle changes to the Model not coming from this ViewModel
            this.model.PropertyChanged += model_PropertyChanged;  // Potential leak?
        }
    
        public void Dispose()
        {
            this.model.PropertyChanged -= model_PropertyChanged;
        }
    }
