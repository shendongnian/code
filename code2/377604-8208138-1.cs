    public partial class ControlPanel : Form
    {
    	public string TrayP
    	{
    		get { return ""; }
    		set { TrayPopup(value, "test");}
        
    	}
        
    	public void ShowForm1(){
    		FOrm1 f1 = new Form1();
    		f1.SetCp(this);
    		f1.show();
    	}
        
    	public void TrayPopup(string message, string title)
    	{
    		TrayIcon.BalloonTipText = message;
    		TrayIcon.BalloonTipTitle = title;
    		TrayIcon.ShowBalloonTip(1);
        }
    }
        
    public partial class Form1 : Form
    {
        
    	public ControlPanel _cp;
    	public void SetCP(controlPanel cp){
                _cp = cp;
    	}
        
    	private void mouse_Up(object sender, MouseEventArgs e) {
                if(_cp != null)
    		    _cp.TrayPopup("TRAY POPUP THIS", "test");
    	}
    }
