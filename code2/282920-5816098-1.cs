    public static void updateSub(int what)
    {
        if (subDisplay.subBox.InvokeRequired)
        {
            subDisplay.subBox.Invoke(new Action<int>(updateSub), what);
        }
        else
        {
            subDisplay.subBox.Text = tb[what];
        }
    }
