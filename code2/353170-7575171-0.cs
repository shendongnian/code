    interface IDataState
    {
        bool CanEdit(string item);
        bool CanDelete(string item);
    }
    
    public partial class ConfigurationManagerControl : UserControl
    {
        public IDataState DataState {get;set;}
        // your code checks DataState.CanEdit & DataState.CanDelete
    }
    
    public class SetupWizard : Form, IDataState
    {
        public SetupWizard()
        {
            InitializeComponent();
            SettingManager.DataState =this;
        }
        public bool CanEdit(string item)
        { 
            ... implement directly or return from your private function
        }
        public bool CanDelete(string item)
        { 
        }
    }
