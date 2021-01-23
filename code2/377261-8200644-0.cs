    delegate void SetProgCallback(int newVal);
    private void SetProgressbarValue(int newVal)
    {
        if (progbar.InvokeRequired)
        {
            SetProgCallback d = SetProgressbarValue;
            Invoke(d, new object[] { newVal });
        }
        else
        {
            //insert your actual code here
        }
    }
