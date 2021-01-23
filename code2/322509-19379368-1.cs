	public void _thinkGearWrapper_ThinkGearChanged(object sender, ThinkGearChangedEventArgs e)
	{
		// update the textbox and sleep for a tiny bit
		BeginInvoke(new MethodInvoker(delegate 
			{
				lblAttention.Text = "Attention: " + e.ThinkGearState.Attention;
				lblMeditation.Text = "Meditation: " + e.ThinkGearState.Meditation;
                attentionvar = e.ThinkGearState.Attention;
                meditationvar = e.ThinkGearState.Meditation;
                attentionstring = attentionvar.ToString();
                meditationstring = meditationvar.ToString();
				txtState.Text = e.ThinkGearState.ToString();
			}));
		Thread.Sleep(10);
        
      senddata();
        
	}
    public void senddata()
    {
        FileStream fs = new FileStream("\\programming\\meditationvariables.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        fs.Close();
        StreamWriter sw = new StreamWriter("\\programming\\meditationvariables.txt", true, Encoding.ASCII);
        string nextline = meditationstring;
        sw.Write(nextline);
        sw.Close();
    }
