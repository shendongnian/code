    public void HeaderInformation()
	{
		// reinitialize headerArray for safety....
		headerArray = new string[2];
		headerArray[0] = DateTime.Now.ToString();
		headerArray[1] = txtFileNumber.Text;
	}
	public void BtnSave_Click(object sender, EventArgs e)
	{
		HeaderInformation();
	}
