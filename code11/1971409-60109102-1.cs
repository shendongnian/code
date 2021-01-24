    void Button1_Clicked(System.Object sender, System.EventArgs e)
    {
        if (Button1.ScaleX < 1)
        {
            Button1.ScaleXTo(1);
        }
        else
        {
            Button1.ScaleXTo(0.5);
        }
    }
