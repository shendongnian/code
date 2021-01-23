    private Stopwatch sw;
    private void FirstCharacterEntered()
    {
    	sw.Start();
    }
    private void txt_TextChanged(System.Object sender, System.EventArgs e)
    {
    	if (txt.length == 0)
    		FirstCharacterEntered();
    	if (txt.Length == BarCodeSerialLength | new RegularExpressions.Regex("your pattern").IsMatch(txt.Text)) {
    		sw.Stop();
    		if (sw.ElapsedMilliseconds < TimeAHumanWouldTakeToType) {
    			//Input is from the BarCode Scanner
    		}
    	}
    }
