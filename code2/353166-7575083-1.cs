    public class SetupWizard : Form, ICantThinkOfAGoodName
    {
        public SetupWizard()
        {
            InitializeComponent();
    
            this.SettingManager.PropertyName = this;
        }
    
        public bool CanEdit(string item)
        {
            var lockedSettings = new[] { "LicenseHash", "ProductHash" };
            return !lockedSettings.Contains(item.ToLower());
        }
    
        public bool CanDelete(string item)
        {
            var lockedSettings = new[] {
                                            "LicenseHash",
                                            "ProductHash", 
                                            "UserName", 
                                            "CompanyName"
                                        };
            return !lockedSettings.Contains(item.ToLower());
        }
    }
    public partial class ConfigurationManagerControl : UserControl
    {
    
        public ICantThinkOfAGoodName PropertyName { get; set;}
    
        public Dictionary<string, string> Settings
        {
            get { return InnerSettings; }
            set
            {
                InnerSettings = value;
                BindData();
            }
        }
        private Dictionary<string, string> InnerSettings;
    
        private void OnListIndexChanged(object sender, EventArgs e)
        {
            this.EditButton.Enabled = false;
            this.DeleteButton.Enabled = false;
    
            var indices = this.List.SelectedIndices;
            if (indices.Count != 1)
            {
                return;
            }
    
            var index = indices[0];
            var item = this.List.Items[index];
    
            if PropertyName  != null)
            {
                this.EditButton.Enabled = PropertyName.CanEdit(item.Text);
                this.DeleteButton.Enabled = this.CanDelete(item.Text);
            }
    
        }
    }
