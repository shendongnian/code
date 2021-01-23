        [DefaultValue((string)null)]
        [Editor(typeof(System.Web.UI.Design.WebControls.DataControlFieldTypeEditor), typeof(UITypeEditor))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public DataControlFieldCollection Columns
        {
            get { return Grid.Columns; }
        }
