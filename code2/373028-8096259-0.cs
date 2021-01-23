    public class NumberTextBox : Control
    {
        static NumberTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberTextBox), new FrameworkPropertyMetadata(typeof(NumberTextBox)));
        }
    }    
    public class DigitBox : WatermarkTextBox, IClearable
    {
        #region Constructors
        ///<summary>
        ///The default constructor
        /// </summary>
        public DigitBox()
        {
            TextChanged += new TextChangedEventHandler(OnTextChanged);
            KeyDown += new KeyEventHandler(OnKeyDown);
            PreviewKeyDown += new KeyEventHandler(OnPreviewDown);
        }
        #endregion
 
        #region Properties
        new public String Text
        {
            get { return base.Text; }
            set
            {
                base.Text = LeaveOnlyNumbers(value);
            }
        }
        #endregion
 
        #region Functions
        public bool IsNumberKey(Key inKey)
        {
            if (inKey < Key.D0 || inKey > Key.D9)
            {
                if (inKey < Key.NumPad0 || inKey > Key.NumPad9)
                {
                    return false;
                }
            }
            return true;
        }
 
        public bool IsActionKey(Key inKey)
        {
            return inKey == Key.Delete || inKey == Key.Back || inKey == Key.Tab || inKey == Key.Return;
        }
 
        public string LeaveOnlyNumbers(String inString)
        {
            String tmp = inString;
            foreach (char c in inString.ToCharArray())
            {
                if (!IsDigit(c))
                {
                    tmp = tmp.Replace(c.ToString(), "");
                }
            }
            return tmp;
        }
        public bool IsSpaceKey(Key inKey)
        {
            if (inKey == Key.Space)
            {
                return true;
            }
            return false;
        }
 
        public bool IsDigit(char c)
        {
            return (c >= '0' || c <='9');
        }
        #endregion
 
        #region Event Functions
        protected virtual void OnKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !IsNumberKey(e.Key) && !IsActionKey(e.Key) && !IsSpaceKey(e.Key);
        }
 
        protected virtual void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            base.Text = LeaveOnlyNumbers(Text);
        }
        protected virtual void OnPreviewDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        #endregion
    }
    public class DateBox : DigitBox
