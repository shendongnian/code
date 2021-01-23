    public partial class Form1: Form
    {
    	public string AskSaveFile()
    	{
    		if (this.InvokeRequired)
    		{
    			Invoke( new MethodInvoker( delegate() { AskSaveFile(); } ) );
    		}
    		else
    		{
    			var sfd = new SaveFileDialog();
    			sfd.Filter = "Fichiers txt (*.txt)|*.txt|Tous les fichiers (*.*)|*.*";
    			sfd.FilterIndex = 1;
    			sfd.RestoreDirectory = true;
    			if(sfd.ShowDialog() == DialogResult.OK) return sfd.FileName; 
            }   			
            return null;
    	}
    }
