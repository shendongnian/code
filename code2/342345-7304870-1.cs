    in Form1:
    
    public void UpdateProgressBar(int index)
    {
    	if (InvokeRequired)
    	{
    		Invoke(new Action<int>(i => UpdateProgressBar(i)), index);
    	}
    	else
    	{
    		prog.updateProgressBar(index);
    	}
    }
    
    
    
    in ClassB:
    
    form1.UpdateProgressBar(index);
