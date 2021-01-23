    public class MyCommonUserControl : UserControl
    {     
        public virtual int CustomProperty     
        {         
            get { return (int)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }
    }
    
    public class FirstMyCommonUserControl : MyCommonUserControl 
    {
        public override int CustomProperty     
        {         
            get 
            { 
                // Do something
                return base.CustomProperty;
            }
            set 
            { 
                // Do something
                base.CustomProperty = value;
            }
        }
    }
