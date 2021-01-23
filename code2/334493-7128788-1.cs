    public abstract class IsValidInputExtension : MarkupExtension
    {
        internal abstract void ValidateInput(object sender, TextCompositionEventArgs e);
        internal abstract void ValidateKeyDown(object sender, KeyEventArgs e);
    }
    public class NumericExtension : IsValidInputExtension
    {
        public double Minimum { get; set; }
        public double Maximum { get; set; }
        public uint Decimals { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        internal override void ValidateInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = (TextBox) sender;
            if (isDecimalSeparator(e.Text) && Decimals == 0)
            {
                e.Handled = true;
                return;
            }
            // todo: honor Minimum and Maximum ...
        }
        private static bool isDecimalSeparator(string s)
        {
            return CultureInfo.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator == s;
        }
        internal override void ValidateKeyDown(object sender, KeyEventArgs e)
        {
            // block [SPACE] when numeric input is expected ...
            e.Handled = e.Key == Key.Space;
        }
    }
    public class StringExtension : IsValidInputExtension
    {
        public double MaximumLength { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        internal override void ValidateInput(object sender, TextCompositionEventArgs e)
        {
            // (nop)
        }
        internal override void ValidateKeyDown(object sender, KeyEventArgs e)
        {
            // todo: honor MaximumLength here
        }
    }
