    private bool CurrentlyFlashing = false;
    private void FlashInternal(TextBox textBox, int interval, Color flashColor, int flashes)
    {
    	if (CurrentlyFlashing) return;
    
    	CurrentlyFlashing = true;
    	Color original = textBox.BackColor;
    	for (int i = 0; i < flashes; i++)
    	{
    		UpdateTextbox(textBox, flashColor);
    		Application.DoEvents();
    		Thread.Sleep(interval / 2);
    		UpdateTextbox(textBox, original);
    		Application.DoEvents();
    		Thread.Sleep(interval / 2);
    	}
    	CurrentlyFlashing = false;
    }
    private delegate void UpdateTextboxDelegate(TextBox textBox, Color originalColor);
    public void UpdateTextbox(TextBox textBox, Color color)
    {
    	if (textBox.InvokeRequired)
    	{
    		this.Invoke(new UpdateTextboxDelegate(UpdateTextbox), new object[] { textBox, color });
    	}
    	textBox.BackColor = color;
    }
