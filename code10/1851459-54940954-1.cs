    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyView : ContentView
     {
        public MyView()
        {
            InitializeComponent();
            List<FirstModel> listFirstModel = new List<FirstModel>();
            listFirstModel.Add(new FirstModel { Key = "Pl", Description = "DescPl" });
            listFirstModel.Add(new FirstModel { Key = "Ps", Description = "DescPs" });
            listFirstModel.Add(new FirstModel { Key = "En", Description = "DescEn" });
            listFirstModel.Add(new FirstModel { Key = "H", Description = "DescH" });
            List<SecondModel> listSecondModel = new List<SecondModel>();
            listSecondModel.Add(new SecondModel { FirstModelKey = "Pl", Key = "Pl1", Description = "SecondModelPl1" });
            listSecondModel.Add(new SecondModel { FirstModelKey = "Pl", Key = "Pl2", Description = "SecondModelPl2" });
            listSecondModel.Add(new SecondModel { FirstModelKey = "Pl", Key = "Pl3", Description = "SecondModelPl3" });
            listSecondModel.Add(new SecondModel { FirstModelKey = "Ps", Key = "Ps1", Description = "SecondModelPs1" });
            listSecondModel.Add(new SecondModel { FirstModelKey = "Ps", Key = "Ps2", Description = "SecondModelPs2" });
            listSecondModel.Add(new SecondModel { FirstModelKey = "Ps", Key = "Ps3", Description = "SecondModelPs3" });
            listSecondModel.Add(new SecondModel { FirstModelKey = "En", Key = "En1", Description = "SecondModelEn1" });
            listSecondModel.Add(new SecondModel { FirstModelKey = "En", Key = "En2", Description = "SecondModelEn2" });
            listSecondModel.Add(new SecondModel { FirstModelKey = "En", Key = "En3", Description = "SecondModelEn3" });
            listSecondModel.Add(new SecondModel { FirstModelKey = "H", Key = "H1", Description = "SecondModelH1" });
            listSecondModel.Add(new SecondModel { FirstModelKey = "H", Key = "H2", Description = "SecondModelH2" });
            listSecondModel.Add(new SecondModel { FirstModelKey = "H", Key = "H3", Description = "SecondModelH3" });
            foreach (FirstModel fm in listFirstModel)
            {
                FirstPicker.Items.Add(fm.Description);
            }
            FirstPicker.SelectedIndexChanged += (sender, e) => {
                SecondPicker.Items.Clear();
                string key = listFirstModel[FirstPicker.SelectedIndex].Key;
                foreach (SecondModel sm in listSecondModel.FindAll(o => o.FirstModelKey == key))
                    SecondPicker.Items.Add(sm.Description);
            };
           // use MessagingCenter to get the SelectedIndex and set it
            MessagingCenter.Subscribe<string, int>("firstpicker", "indext", (sender, args) => {
                FirstPicker.SelectedIndex = args;
            });
            MessagingCenter.Subscribe<string, int>("secondpicker", "indext", (sender, args) => {
                SecondPicker.SelectedIndex = args;
            });
        }
        
    }
