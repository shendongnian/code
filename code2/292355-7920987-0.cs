    public class frmOptions
    {
        CustomSettings MySettings = new CustomSettings();
        
        private frmOptions_Load(object sender, EventArgs e)
        {
            PropertyGrid1.SelectedObject = MySettings;
        }
    }
