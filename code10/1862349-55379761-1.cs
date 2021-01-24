<ListView ItemsSource="{Binding Service.MyList}" />
ViewModel
private IService _service;
public IService Service
{
   get => _service;
   set
   {
       _service = value;
       RaisePropertyChanged(nameof(Service));
       // So whenever _service is changed, it will generate an event.
       // UI will get Service.MyList.
   }
}
// No Observable collection.
2nd Solution.
// When _service is changed.
_service.PropertyChanged += Service_PropertyChanged;
    // Manually raise event to update list.
    private void Service_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "MyList")
            OnPropertyChanged(nameof(ViewModelList));
    }
