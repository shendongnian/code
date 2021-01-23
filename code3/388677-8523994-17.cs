        public static int GetInt32<T>(T target) where T : IConvertible
        {
            bool? isInt = IsInteger<T>(target);
            if (isInt == null) throw new ArgumentException(); // put an appropriate message in
            else if (isInt == true)
            {
                try
                {
                    int i = target.ToInt32(CultureInfo.InvariantCulture);
                    return i;
                }
                catch
                {   // exceeded size of int32
                    throw new OverflowException(); // put an appropriate message in
                }
            }
            else
            {
                try
                {
                    double d = target.ToDouble(CultureInfo.InvariantCulture);
                    return (int)Math.Round(d);
                }
                catch
                {   // exceeded size of int32
                    throw new OverflowException(); // put an appropriate message in
                }
            }
        }
