    List<Control> myControls = new List<Control>();
    myControls.Add(new Label());
    myControls.Add(new Button());
    myControls.Add(new PictureBox());
    foreach (var myControl in myControls)
    {
         myControl.Name = "New Name";
         myControl.Size = new Size(100, 200);
         myControl.Location = new Point(100, 100);
    }
