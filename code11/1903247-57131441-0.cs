    private void setControlVisibility<T>(bool b) where T : Control
    {
        foreach (Control a in grpControls.Controls)
        {
            if (a.GetType() == typeof(T)) // checking type of generic parameter "T"
            {
                a.Visible = b;
            }
        }
    }
