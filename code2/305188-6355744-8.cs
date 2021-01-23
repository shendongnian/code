    public class SettingsExample
    {
    	private Form1 frmMain = new Form1();
    
    	public void Main()
    	{
    		frmMain.BackColor = My.Settings.DefaultBackColour;
    	}
    
    	public void UserLoggedIn()
    	{
    		frmMain.BackColor = My.Settings.UserBackcolour;
    	}
    
    	public void UpdateUserBackcolour(System.Drawing.Color newColour)
    	{
    		My.Settings.UserBackcolour = newColour;
    		My.Settings.Save();
    	}
    
    	public void UpdateDefaultBackcolour(System.Drawing.Color newColour)
    	{
    		My.Settings.DefaultBackColour = newColour;
    		// Compiler Error
    		// This property is read only because it is an application setting
    		// Only user settings can be changed at runtime
    	}
    
    }
