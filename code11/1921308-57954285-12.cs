     public partial class MainPage : ContentPage
    {
        ObservableCollection<TestModel> items = new ObservableCollection<TestModel>();
        MyViewModel testModel = null;
        public MainPage()
        {
            InitializeComponent();
            testModel = new MyViewModel();
            BindingContext = testModel;
            //This will also work
            //if (testModel!=null && testModel.PickerChoices!=null) {
            //  for (int index=0;index< testModel.PickerChoices.Count;index++ ) {
            //        TestModel temp = testModel.PickerChoices[index];
            //    if (18 == temp.MyID) {
            //            mypicker.SelectedIndex = index;
            //            break;
            //     }
            //   }
            //}
            foreach (TestModel model in testModel.PickerChoices)
            {
                if (model.MyID == 18)
                {// default value
                    testModel.SelectedRecord = model;
                    break;
                }
            }
        }
        // to show the selected item
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (testModel.SelectedRecord!=null) {
            DisplayAlert("Alert", "selected Item  MyID : " + testModel.SelectedRecord.MyID + "<--> ShowValue: " + testModel.SelectedRecord.ShowValue, "OK");
            }
        }
    }
