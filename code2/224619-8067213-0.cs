     //.aspx
     Control c = Page.LoadControl("LayoutSize.ascx");
     c.GetType().GetProperty("Get_Editor_Mode").SetValue(c, True, null);
    //.ascx
        private bool Editor_Mode = false;
        public bool Get_Editor_Mode
        {
            get { return Editor_Mode; }
            set { Editor_Mode = value; }
        }
