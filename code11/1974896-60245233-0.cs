    public partial class AddInstitutionStart : Window
    {
        public AddInstitutionStart()
        {
            InitializeComponent();
            foreach(string cat in new FillCombo().fillInstCategory())
                ComboBoxInstitutionCategory.Items.Add(cat);
        }
    }
