	public void modifyDigitalPins(byte address, byte length)
	{
		int startPin = (byte)address;
		int numberPins = (byte)length;
		for(int i=1; i <= numberPins; i++)
		{
			Control ctl = this.Controls.Find("checkBox" + (startPin + (i - 1)).ToString(), true).FirstOrDefault();
			if (ctl != null && ctl is CheckBox)
			{
				CheckBox cb = (CheckBox)ctl;
				cb.Checked = true;
			}
		}
	}
