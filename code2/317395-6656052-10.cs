    private void LoadMyUserControl(string controlName) {
        DynamicUserControlBase control = (DynamicUserControlBase)LoadControl(controlName);
        // Do some stuff     
        control.UpdateParent += new EventHandler<EventArgs>(HandledEvent);
    }
    private void HandledEvent(object sender, EventArgs e) {
        throw new NotImplementedException();
    }
