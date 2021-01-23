    class DummyComboBoxItem
    {
        public string DisplayName
        {
            get
            {
                return "Make a selection ...";
            }
        }
    }
	public partial class mainForm : Form
    {
        private DummyComboBoxItem placeholder = new DummyComboBoxItem();
        public mainForm()
        {
			InitializeComponent();
			
            myComboBox.DisplayMember = "DisplayName";            
            myComboBox.Items.Add(placeholder);
            foreach(object o in Objects)
            {
                myComboBox.Items.Add(o);
            }
            myComboBox.SelectedItem = placeholder;
		}
	
        private void myComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (myComboBox.SelectedItem == null) return;
            if (myComboBox.SelectedItem == placeholder) return;            
			/*
				do your stuff
			*/
            myComboBox.Items.Add(placeholder);
            myComboBox.SelectedItem = placeholder;
        }
        private void myComboBox_DropDown(object sender, EventArgs e)
        {
            myComboBox.Items.Remove(placeholder);
        }
        private void myComboBox_Leave(object sender, EventArgs e)
        {
			//this covers user aborting the selection (by clicking away or choosing the system null drop down option)
			//The control may not immedietly change, but if the user clicks anywhere else it will reset
            if(myComboBox.SelectedItem != placeholder)
            {
                if(!myComboBox.Items.Contains(placeholder)) myComboBox.Items.Add(placeholder);
                myComboBox.SelectedItem = placeholder;
            }            
        }		
	}
	
