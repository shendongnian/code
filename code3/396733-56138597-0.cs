    public class DropList : Button
    {
        public event EventHandler TextChangedByUser;
        private ContextMenu _CM = new ContextMenu();
        private string[] _Items;
        public string[] Items
        {
            get { return _Items; }
            set
            {
                _Items = value;
                _CM.MenuItems.Clear();
                foreach (string sChoice in _Items)
                {
                    MenuItem MI = _CM.MenuItems.Add(sChoice, MI_Click);
                }
            }
        }
        private void MI_Click(object sender, EventArgs e)
        {
            if (this.Text != (sender as MenuItem).Text)
            {
                this.Text = (sender as MenuItem).Text;
                if (TextChangedByUser != null) TextChangedByUser.Invoke(this, new EventArgs());
            }
        }
        
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _CM.Show(this, new System.Drawing.Point(0, this.Height - 1));
        }
    }
