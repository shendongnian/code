    public class ScreenElement{
        public string Author {get;set;}
        public DateTime DateCreated {get;set;}
    }
    // XAML can not directly deal with generics so this step is
    // necessary
    public class ScreenElements : ObservableCollection<ScreenElement>
    {
    }
    [ContentProperty("Elements")]
    public class Screen
    {
        public Screen(){
            this.Elements = new ScreenElements();
        }
        public string Title{get;set;}
        public bool ToolbarPresent {get;set;}
        // this attribute is necessary if 
        // you want to save Screen to xaml
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ScreenElements Elements {get; private set;}
    }
