    private class edgFooterTemplate : ITemplate
    {
        private Button btn_Edit;
        public edgFooterTemplate()
        {
            btn_Edit = new Button();
            btn_Edit.CausesValidation = false;
            btn_Edit.CommandName = "Edit";
            btn_Edit.ID = "btn_Edit";
            btn_Edit.Text = "Edit";
        }
        public event EventHandler EditClick
        {
            add { this.btn_Edit.Click += value; }
            remove { this.btn_Edit.Click -= value; }
        }
        public void InstantiateIn(Control container)
        {
            if (container != null)
            {
                container.Controls.Add(btn_Edit);
            }
        }
    }
