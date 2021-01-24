    public class SuperForm : Form
    {
        private bool _isFormActive = false;
        public bool isFormActive
        {
            get
            {
                return this._isFormActive;
            }
    
            set
            {
                this._isFormActive = value;
            }
        }
    
        protected override void OnLoad(EventArgs e)
        {
            this.isFormActive = true;
            AppForms.Add(this);
            base.OnLoad(e);
        }
    
        protected override void OnClosed(EventArgs e)
        {
            this.isFormActive = false;
            AppForms.Remove(this);
            base.OnClosed(e);
        }
    }
