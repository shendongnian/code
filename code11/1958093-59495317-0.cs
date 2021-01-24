    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerView : ContentView
    {
        public Group SelectGroup; // add the SelectGroup property which save the result after you select
        public ObservableCollection<Group> pickerSource { get; set; }
        public PickerView(ObservableCollection<Group> source) //here i change the source to your Group model
        {
            InitializeComponent();
            picker.ItemsSource = source;
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var stack = this.Parent as StackLayout;
            stack.Children.Remove(this);
        }
        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            SelectGroup = (Group)picker.SelectedItem;    
        }
    }
