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
