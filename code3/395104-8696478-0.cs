    List<Control> controls = new List<Control>();
    controls.AddRange(superTabControlPanel1.Controls.GetControls());
    controls.AddRange(superTabControlPanel2.Controls.GetControls());
    foreach(Control ctrl in controls){
        //Do something
    }
