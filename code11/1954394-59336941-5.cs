    public static bool i = false;
    private void BtnDark_Click(object sender, EventArgs e)
    {
        //i = true;  JUST REMOVE THIS LINE
        if (i) // Darkmode
        {
            //...
            i = false;
        }
        else // Whitemode
        {
            //...
            i = true;
        }
    }
