    /// <summary>
    /// A numeric-only textbox.
    /// </summary>
    public class NumericOnlyTextBox : TextBox
    {
        #region Properties
        #region AllowDecimals
        
        /// <summary>
        /// Gets or sets a value indicating whether [allow decimals].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow decimals]; otherwise, <c>false</c>.
        /// </value>
        public bool AllowDecimals
        {
            get { return (bool)GetValue(AllowDecimalsProperty); }
            set { SetValue(AllowDecimalsProperty, value); }
        }
        
        /// <summary>
        /// The allow decimals property
        /// </summary>
        public static readonly DependencyProperty AllowDecimalsProperty =
            DependencyProperty.Register("AllowDecimals", typeof(bool), 
            typeof(NumericOnlyTextBox), new UIPropertyMetadata(false));
        
        #endregion
        #region MaxValue
        /// <summary>
        /// Gets or sets the max value.
        /// </summary>
        /// <value>
        /// The max value.
        /// </value>
        public double? MaxValue
        {
            get { return (double?)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }
        /// <summary>
        /// The max value property
        /// </summary>
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double?), 
            typeof(NumericOnlyTextBox), new UIPropertyMetadata(null));
        #endregion
        #region MinValue
        
        /// <summary>
        /// Gets or sets the min value.
        /// </summary>
        /// <value>
        /// The min value.
        /// </value>
        public double? MinValue
        {
            get { return (double?)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }
        /// <summary>
        /// The min value property
        /// </summary>
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(double?), 
            typeof(NumericOnlyTextBox), new UIPropertyMetadata(null));
        
        #endregion
        #endregion
        #region Contructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericOnlyTextBox" /> class.
        /// </summary>
        public NumericOnlyTextBox()
        {
            this.PreviewTextInput += OnPreviewTextInput;        
        }
        
        #endregion
        #region Methods
        /// <summary>
        /// Numeric-Only text field.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public bool NumericOnlyCheck(string text)
        {
            // regex that matches disallowed text
            var regex = (AllowDecimals) ? new Regex("[^0-9.]+") : new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }
        #endregion
        #region Events
        /// <summary>
        /// Called when [preview text input].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextCompositionEventArgs" /> instance 
        /// containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Check number
            if (this.NumericOnlyCheck(e.Text))
            {
                // Evaluate min value
                if (MinValue != null && Convert.ToDouble(this.Text + e.Text) < MinValue)
                {
                    this.Text = MinValue.ToString();
                    this.SelectionStart = this.Text.Length;
                    e.Handled = true;
                }
                // Evaluate max value
                if (MaxValue != null && Convert.ToDouble(this.Text + e.Text) > MaxValue)
                {
                    this.Text = MaxValue.ToString();
                    this.SelectionStart = this.Text.Length;
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
        
        #endregion
    }
