    public enum FieldTypes
    {
      Constant,
      Variable,
    }
    
    // Don't forget to set up your INotifyPropertyChanged on your properties
    // if they are being used for binding
    public class HiddenFieldPanelViewModel
    {
        public List<HiddenFieldComponent> HiddenFieldList { get; set; }
        public HiddenFieldComponent Component { get; set; }
        public bool IsVisible { get; set; }
        // removed:
        // public enum FieldTypes{Constant,Variable}
        
        // will likely want to set up a property such as:
        // public enum FieldTypes {get; set;}
        public HiddenFieldPanelViewModel()
        {
            HiddenFieldList = new List<HiddenFieldComponent>();
            IsVisible = false;
        }
    }
