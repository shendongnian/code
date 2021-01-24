    private List<MyUserControl> userControls = new List<MyUserControl>();
    private void AddUCsToList(int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            var uc = new MyUserControl();
            uc.ControlRemoveNotify += (obj, evt) => { RemoveControl((MyUserControl)obj); };
            userControls.Add(uc);
            flowLayoutPanel1.Controls.Add(uc);
        }
    }
    private void RemoveControl(MyUserControl uc)
    {
        userControls.Remove(uc);
        uc.Dispose();
    }
