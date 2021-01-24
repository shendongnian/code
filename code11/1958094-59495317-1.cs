    public partial class MutiPicker : ContentPage
    {
        public MutiPicker()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var source = new ObservableCollection<Group>() { new Group() { ID=111,GroupName="AAA",SubsID=1}, new Group() { ID = 222, GroupName = "BBB", SubsID = 2 }, new Group() { ID = 333, GroupName = "CCC", SubsID = 3 } };
            pickerStack.Children.Add(new PickerView(source));
        }
        //iterate over your pickerviews
        private void Update_Clicker(object sender, EventArgs e)
        {
            foreach (var pickerview in pickerStack.Children)
            {
                if (pickerview is PickerView && ((PickerView)pickerview).SelectGroup != null)
                {
                    var selectgroup = ((PickerView)pickerview).SelectGroup;//here you will get your select group,then you could get its ID ,GroupName or SubsID 
                }
                
            }
        }
    }
