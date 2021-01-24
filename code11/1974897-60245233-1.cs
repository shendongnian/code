    public partial class AddInstitutionStart : Window
    {
        public AddInstitutionStart()
        {
            InitializeComponent();
            new FillCombo().fillInstCategory(ComboBoxInstitutionCategory.Items.Add)) //note there is no "(" and ")" after Add, so the addition doesnt happen, just the function was passed to "fillInstCategory" to use it whenever necessary.
        }
    }
