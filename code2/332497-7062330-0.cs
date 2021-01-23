    void rb_CheckedChanged(x, y)
    {
        if (hiddenField.Value == "False")
        {
            LoadSomeData(); //need to load only once.
            hiddenField.Value = true.ToString();
        }
        else
        {
             // Do nothing.
        }
        // rest of the code; to be executed every single time..
    }
