    [DefaultProperty("Value"), DefaultBindingProperty("Value")]
    public class NumericTextBox : TextBox
    {
        string formatting;
        double value;
        public NumericTextBox()
        {
            this.formatting = "g";
            this.value = 0.0;
            base.ReadOnly = true;
            base.Text = "0.0";
        }
        [Category("Data")]
        [SettingsBindable(true)]
        [DefaultValue("g")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(BindableSupport.Yes)]
        public string Formatting
        {
            get => formatting;
            set
            {
                if (formatting == value)
                {
                    return;
                }
                this.formatting= value;
                OnFormattingChanged(this, EventArgs.Empty);
                try
                {
                    base.Text = Value.ToString(value);
                }
                catch (FormatException ex)
                {
                    Trace.WriteLine(ex.ToString());
                    base.Text = Value.ToString();
                }
            }
        }
        public event EventHandler FormattingChanged;
        protected void OnFormattingChanged(object sender, EventArgs e) => FormattingChanged?.Invoke(sender, e);
        [Category("Data")]
        [SettingsBindable(true)]
        [DefaultValue(0.0)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(BindableSupport.Yes)]
        public double Value
        {
            get => this.value;
            set
            {
                if (this.value == value)
                {
                    return;
                }
                this.value=value;
                OnValueChanged(this, EventArgs.Empty);
                base.Text = value.ToString(Formatting);
            }
        }
        public event EventHandler ValueChanged;
        protected void OnValueChanged(object sender, EventArgs e) => ValueChanged?.Invoke(sender, e);
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            base.ReadOnly = true;
            if (double.TryParse(base.Text, out double x))
            {
                base.Text = x.ToString(Formatting);
                this.Value = x;
            }
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            base.ReadOnly = false;
            base.Text = Value.ToString("R");
        }
    }
