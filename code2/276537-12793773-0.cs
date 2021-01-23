    [DllImport("winmm.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
	public static extern long GetNumDevs();
	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		long I = 0;
		I = GetNumDevs();
		if (I > 0) {
			Interaction.MsgBox("Your system can play sound files.");
		} else {
			Interaction.MsgBox("Your system can not play sound files.");
		}
	}
