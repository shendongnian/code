    public partial class View1 : ContentView
	{
		public View1 ()
		{
			InitializeComponent ();          
        }
        public static readonly BindableProperty Label1Property= BindableProperty.Create(
                        nameof(Label1),
            typeof(string),
            typeof(View1),
            "",
            BindingMode.TwoWay,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                if (newValue != null && bindable is View1 control)
                {
                    var actualNewValue = (string)newValue;
                    control.label1.Text = actualNewValue;
                }
            });
        public string Label1 { get; set; }
        public static readonly BindableProperty Label2Property = BindableProperty.Create(
                        nameof(Label2),
            typeof(string),
            typeof(View1),
            "",
            BindingMode.TwoWay,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                if (newValue != null && bindable is View1 control)
                {
                    var actualNewValue = (string)newValue;
                    control.label2.Text = actualNewValue;
                }
            });
        public string Label2 { get; set; }
    }
