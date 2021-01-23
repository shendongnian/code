    public partial class SettingsForm : Form
    {
       public bool Is60Hz {get; private set;}
       ...
       private void notch50Hz_Checked(object sender, EventArgs e)
       {
            notch50hzbutton.Checked = true;
            Is60Hz = false;
       }
       private void notch60Hz_Checked(object sender, EventArgs e)
       {
            notch60hzbutton.Checked = true;
            Is60Hz = true;
       }
