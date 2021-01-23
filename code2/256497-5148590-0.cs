    public abstract class MyUserControl: UserControl
    {
         public void ToggleLegend()
        {
            Chart1.Legends[0].Enabled = !Chart1.Legends[0].Enabled;
        }
        public override void CreateChildControls()
        {
            Controls.Add(Page.LoadControl("path/to/mymarkup/control"));
            // or add them in code
            BuildBaseControls();
        }
    }
