    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private int firstSelectedIndex;
        private int secondSelectedIndex;
        public HomePage()
        {
            InitializeComponent();
            //find the picker control and set listener
            Picker p = mv.FindByName<Picker>("FirstPicker");
            Picker s = mv.FindByName<Picker>("SecondPicker");
            p.SelectedIndexChanged += FirstPicker_SelectedIndexChanged;
            s.SelectedIndexChanged += SecondPicker_SelectedIndexChanged;
        }
        void FirstPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            firstSelectedIndex = picker.SelectedIndex;
            if (firstSelectedIndex != -1)
            {
                lbl_firstpicker.Text = picker.Items[firstSelectedIndex];
            }
            
        }
        void SecondPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            secondSelectedIndex = picker.SelectedIndex;
            if (secondSelectedIndex != -1)
            {
                lbl_secondpicker.Text = picker.Items[secondSelectedIndex];
            }
        }
        // navigation to detailpage and notice Picker to set the selected indext
        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailPage());
            MessagingCenter.Send<string, int>("firstpicker", "indext", firstSelectedIndex);
            MessagingCenter.Send<string, int>("secondpicker", "indext", secondSelectedIndex);
        }
    }
