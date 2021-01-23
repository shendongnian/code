    public class FractionalUpDown: NumericUpDown {
        //Hide Hexadecimal
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool Hexadecimal {
            get { return false; }
            set { base.Hexadecimal = false; }
        }
        private EMode mode;
        [DefaultValue(EMode.Fractional)]
        public EMode Mode {
            get { return mode; }
            set {
                if (value != mode) {
                    mode = value;
                    UpdateEditText();
                }
            }
        }
        public enum EMode {
            Fractional,
            FractionalMixed,
            FractionalASCII,
            FractionalMixedASCII,
            Decimal
        }
        public FractionalUpDown() {
        }
        protected override void UpdateEditText() {
            if (Mode == EMode.Decimal) {
                base.UpdateEditText();
                return;
            }
            double accuracy = Math.Pow(10.0, -(DecimalPlaces + 1));
            if (accuracy > 0.1) accuracy = 0.1;
            this.Text = FractionToString(DoubleToFraction((double)Value, accuracy), Mode);
        }
        public struct Fraction {
            public Fraction(int n, int d) {
                N = n;
                D = d;
            }
            public int N { get; private set; }
            public int D { get; private set; }
        }
        private static readonly char[] numbers = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static readonly char[] numerators = new char[10] { '⁰', '¹', '²', '³', '⁴', '⁵', '⁶', '⁷', '⁸', '⁹' };
        private static readonly char[] denumerators = new char[10] { '₀', '₁', '₂', '₃', '₄', '₅', '₆', '₇', '₈', '₉' };
        protected string FractionToString(Fraction frac, EMode mode) {
            int full = 0;
            int n = frac.N;
            string result = string.Empty;
            bool mixed = mode == EMode.FractionalMixed ||
                         mode == EMode.FractionalMixedASCII;
            bool useFractionalChars = mode == EMode.Fractional ||
                                      mode == EMode.FractionalMixed;
            if (mixed && Math.Abs(frac.N) >= frac.D) {
                full = frac.N / frac.D;
                n = Math.Abs(frac.N % frac.D);
                if (full != 0) result = full.ToString();
                else if (n == 0) return "0";
            }
            if (n != 0) {
                string fracNtext = n.ToString();
                string fracDtext = frac.D.ToString();
                if (useFractionalChars) {
                    for (int i = 0; i < 10; i++) fracNtext = fracNtext.Replace(numbers[i], numerators[i]);
                    for (int i = 0; i < 10; i++) fracDtext = fracDtext.Replace(numbers[i], denumerators[i]);
                } else {
                    if (full != 0) result += " ";
                }
                result += fracNtext + '⁄' + fracDtext;
            } else {
                //Fractional Part == 0/?
                if (full == 0) {
                    if (mixed == true) {
                        return "0";
                    } else {
                        if (useFractionalChars) {
                            return numerators[0].ToString() + '⁄' + denumerators[1].ToString();
                        } else {
                            return numbers[0].ToString() + '⁄' + numbers[1].ToString();
                        }
                    }
                }
            }
            return result;
        }
        //Source: https://stackoverflow.com/questions/5124743/algorithm-for-simplifying-decimal-to-fractions/32903747#32903747
        protected Fraction DoubleToFraction(double value, double accuracy) {
            if (accuracy <= 0.0 || accuracy >= 1.0) {
                throw new ArgumentOutOfRangeException("accuracy", "Must be > 0 and < 1.");
            }
            int sign = Math.Sign(value);
            if (sign == -1) {
                value = Math.Abs(value);
            }
            // Accuracy is the maximum relative error; convert to absolute maxError
            double maxError = sign == 0 ? accuracy : value * accuracy;
            int n = (int)Math.Floor(value);
            value -= n;
            if (value < maxError) {
                return new Fraction(sign * n, 1);
            }
            if (1 - maxError < value) {
                return new Fraction(sign * (n + 1), 1);
            }
            // The lower fraction is 0/1
            int lower_n = 0;
            int lower_d = 1;
            // The upper fraction is 1/1
            int upper_n = 1;
            int upper_d = 1;
            while (true) {
                // The middle fraction is (lower_n + upper_n) / (lower_d + upper_d)
                int middle_n = lower_n + upper_n;
                int middle_d = lower_d + upper_d;
                if (middle_d * (value + maxError) < middle_n) {
                    // real + error < middle : middle is our new upper
                    Seek(ref upper_n, ref upper_d, lower_n, lower_d, (un, ud) => (lower_d + ud) * (value + maxError) < (lower_n + un));
                    upper_n = middle_n;
                    upper_d = middle_d;
                } else if (middle_n < (value - maxError) * middle_d) {
                    // middle < real - error : middle is our new lower
                    Seek(ref lower_n, ref lower_d, upper_n, upper_d, (ln, ld) => (ln + upper_n) < (value - maxError) * (ld + upper_d));
                    lower_n = middle_n;
                    lower_d = middle_d;
                } else {
                    // Middle is our best fraction
                    return new Fraction((n * middle_d + middle_n) * sign, middle_d);
                }
            }
        }
        /// <summary>
        /// Binary seek for the value where f() becomes false.
        /// Source: https://stackoverflow.com/questions/5124743/algorithm-for-simplifying-decimal-to-fractions/32903747#32903747
        /// </summary>
        protected void Seek(ref int a, ref int b, int ainc, int binc, Func<int, int, bool> f) {
            a += ainc;
            b += binc;
            if (f(a, b)) {
                int weight = 1;
                do {
                    weight *= 2;
                    a += ainc * weight;
                    b += binc * weight;
                }
                while (f(a, b));
                do {
                    weight /= 2;
                    int adec = ainc * weight;
                    int bdec = binc * weight;
                    if (!f(a - adec, b - bdec)) {
                        a -= adec;
                        b -= bdec;
                    }
                }
                while (weight > 1);
            }
        }
    }
