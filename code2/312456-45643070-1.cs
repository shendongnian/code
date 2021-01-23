     public partial class PersonInfoView : UserControl
      {
        public PersonInfoView()
        {
            InitializeComponent();
            Messenger.Default.Register<PersonInfoMsg>(this, OnErrorMsg);
        }
        private void OnErrorMsg(PersonInfoMsg)
        {
            // In case of DataGrid validation
            foreach (PersonInfoModel p in GridName.ItemsSource)
            {
                if (p.ValidationErrors.Count == 0)
                    SaveBtn.IsEnabled = true;
                else
                    SaveBtn.IsEnabled = false;
            }
         }
      }
