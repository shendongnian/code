	public void Main()
	{
		try
        {
			string strMessage = Dts.Variables["User::FinalTieOut"].Value.ToString();
			Messagebox.Show(strMessage);
			Dts.TaskResult = (int)ScriptResults.Success;
		
		}
        catch(Exception ex)
        {
			Dts.Events.FireError(0,"An error occured", ex.Message,String.Empty, 0);
			Dts.TaskResult = (int)ScriptResults.Failure;
		}
	}
