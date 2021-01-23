        public class UserControl1 : UserControl
        {
           public UserControl1()
           {
               InitializeComponent();
               this.InitialValue = 10;
           }
    
           [Category("Main")]
           [Description("Intial Value")]
           [DefaultValue(10)]
           public int InitialValue
           {
               get { return m_initialValue; }
               set
               {
                   m_initialValue = value;
                   this.trackBar1.Value = this.m_initialValue;
               }
           }
    
           int m_initialValue;
        }
