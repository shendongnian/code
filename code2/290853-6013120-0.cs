    List<Control> list = new List<Control>();
    public void ControlRecursive(Control Root)
        {
            if(typeof(ComboBox) == Root.GetType() && ((ComboBox)Root).Checked)
                list.Add(Root);
            // if all your other types
            // ...
            foreach (Control Ctl in Root.Controls)
                ControlRecursive(Ctl);
        }
