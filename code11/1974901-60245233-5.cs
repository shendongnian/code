    public partial class AddInstitutionStart : Window
    {
        public AddInstitutionStart()
        {
            InitializeComponent();
            ComboBoxInstitutionCategory.Items.AddRange(new FillCombo().fillInstCategory());
        }
    }
