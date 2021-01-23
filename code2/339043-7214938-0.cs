    public partial class Form1: Form
    {
    	public string AskSaveFile()
    	{
    		if (this.InvokeRequired)
    		{
    			BeginInvoke( new MethodInvoker( delegate() { AskSaveFile(); } ) );
    		}
    		else
    		{
    			var sfd = new SaveFileDialog();
    			sfd.Filter = "Fichiers txt (*.txt)|*.txt|Tous les fichiers (*.*)|*.*";
    			sfd.FilterIndex = 1;
    			sfd.RestoreDirectory = true;
    			DialogResult result = (DialogResult) Invoke(new Action(() => sfd.ShowDialog(this)));
    			if(result == DialogResult.OK)
    			{
    				return sfd.FileName;
    			}
    		return null;
    	}
    }
