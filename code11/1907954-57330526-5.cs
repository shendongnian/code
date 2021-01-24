    private List<MyUserControl> userControls = new List<MyUserControl>();
    private void AddUCsToList(int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            var uc = new MyUserControl();
            void RemoveControl(object s, EventArgs e)
            {
                uc.ControlRemoveNotify -= RemoveControl;
                userControls.Remove(uc);
                uc.Dispose();
            };
            uc.ControlRemoveNotify += RemoveControl;
            userControls.Add(uc);
            flowLayoutPanel1.Controls.Add(uc);
        }
    }
