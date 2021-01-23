        private double _value = 0;
        [
        Bindable(true, BindingDirection.TwoWay),
        Browsable(true),
        DefaultValue(0),
        PersistenceMode(PersistenceMode.Attribute)
        ]
        public double Value
        {
            get
            {
                double d = 0;
                Double.TryParse(ValueControlTextBox.Text,out d);
                return d;
            }
            set
            {   
                ValueControlTextBox.Text = String.Format("{0:0.00}", value);
                _value = value;
            }
        }
