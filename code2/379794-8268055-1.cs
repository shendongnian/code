    public class MyUserControl
    {
        public event EventHandler MyClick;
        private void OnMyClick()
        {
            if (this.MyClick != null)
                this.MyClick(this, EventArgs.Empty);
        }
        public MyUserControl()
        {
            this.Click += (sender, e) => this.OnMyClick();
        }
    }
