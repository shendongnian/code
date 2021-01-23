    public partial class WrappingControl<T> : UserControl where T : UIElement
    {
        public T WrappedControl { get; set; } // Add appropriate logic
    }
    var wc2 = new WrappingControl<CheckBox>();
    wc2.WrappedControl = new CheckBox();
    wc2.WrappedControl.IsChecked = true;
