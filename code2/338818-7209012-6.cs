    private int currentCount, allowedCount;
    private void UpdateLabel()
    {
        if (InvokeRequired)
        {
            Invoke(new MethodInvoker(UpdateLabel));
        }
        else
            labelCount.Text = "Using " + currentCount.ToString() + " of " + allowedCount.ToString();
    }
