    // Console Application
    // Load System.Windows.Forms reference.
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern int AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
    
    class SlidingForm: System.Windows.Forms.Form 
    {
    	const int AW_HIDE = 0X10000;
    	const int AW_ACTIVATE = 0X20000;
    	const int AW_HOR_POSITIVE = 0X1;
    	const int AW_HOR_NEGATIVE = 0X2;
    	const int AW_SLIDE = 0X40000;
    	const int AW_BLEND = 0X80000;
    
    	protected override void OnLoad(System.EventArgs e)
    	{
    		AnimateWindow(this.Handle, 1000, AW_ACTIVATE | AW_SLIDE | AW_HOR_POSITIVE);
    		base.OnLoad(e);
    	}
    }
    
    void Main()
    {
    	var frm = new SlidingForm();
    	frm.ShowDialog();
    }
