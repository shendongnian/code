    private ObservableCollection<Element> _elements;
    
    public ObservableCollection Elements {
        get { return _elements; }
        set {
            _elements = value;
            var VMs = _elements.Select(el => new ElementVM(el, Visibility.Visible);
            _elementsVM = new ObservableCollection<ElementVM>(VMs);
            //NotifyPropertyChanged ("ElementVM")
        }
    }
    
    privae ObserableCollection<ElementVM> _elementsVM;
    
    public ObservableCollection ElementsVM {
        get { return _elementsVM; }
    }
    
    public class ElementVM: INotifyPropertyChanged {
        public Element Element { get; set; }
        public Visibility IsVisible { get; set; }
    
        public ElementVM (Element element, Visibility visibility) {
            Element = element;
            IsVisible = visibility;
        }
        // Implement INotifyPropertyChanged here 
    }
