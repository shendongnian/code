    class myClass : TextBox
    {
        public virtual string TextWithoutEvents
        {
            get
            {
                
                return base.Text;
            }
            set
            {
                bool oldState = Enabled;
                Enabled = false;
                base.Text = value;
                Enabled = oldState;
            }
        }
    }
