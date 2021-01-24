    public class MainViewModel
    {
        public ObservableCollection<TypeMappingViewModel> MappedTypes { get; }
            = new ObservableCollection<TypeMappingViewModel>
        {
            new TypeMappingViewModel { MappedTypeName = "System.Threading.Tasks.Task" },
            new TypeMappingViewModel { MappedTypeName = "System.Type" }
        };
        public TypeMappingViewModel SelectedType { get; set; }
    }
