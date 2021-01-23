    class derived : first
    {
        protected override void OnClick(EventArgs e)
        {
            MessageBox.Show("derived");
            base.OnClick(e);
        }
    }
