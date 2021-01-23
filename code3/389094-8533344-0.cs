    foreach (Control ctrl in ctrlContainer.Controls)
    {
        // code to find my specific sub classed textBox
        // found my control
        // now update my new property _key
        if (ctrl is MyControl)
        {
            MyControl myControl = (MyControl)ctrl;
            myControl._key = "";
        }
    }
