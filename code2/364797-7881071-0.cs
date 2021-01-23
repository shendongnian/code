       // Declare a delegate 
    public delegate void ValueChangedEventHandler(object sender, 
                                  ValueChangedEventArgs e);
    public partial class SampleUserControl : TextBox 
    {
    
        public SampleUserControl() 
        { 
            InitializeComponent(); 
        }
    
        // Declare an event 
        public event ValueChangedEventHandler ValueChanged;
    
        protected virtual void OnValueChanged(ValueChangedEventArgs e) 
        { 
            if (ValueChanged != null) 
                ValueChanged(this,e); 
        }
    
        private void SampleUserControl_TextChanged(object sender, 
                                         EventArgs e) 
        { 
            TextBox tb  = (TextBox)sender; 
            int value; 
            if (!int.TryParse(tb.Text, out value)) 
                value = 0; 
            // Raise the event 
           OnValueChanged( new ValueChangedEventArgs(value)); 
        }
    
    }
