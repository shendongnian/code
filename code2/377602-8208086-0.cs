    public partial class Form1 : Form
    {
    
        public ControlPanel cp = new ControlPanel();
        ....
    
        private void mouse_Up(object sender, MouseEventArgs e) {   
        CP.TrayPopup("TRAY POPUP THIS", "test");
        }
    }
