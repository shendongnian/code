            public static bool? IsInteger<T>(T testNumber) where T : IConvertible
            {
                // returns null if T is non-numeric
                bool? isInt = null;
                try
                {
                    isInt = testNumber.ToUInt64(CultureInfo.InvariantCulture) == testNumber.ToDouble(CultureInfo.InvariantCulture);
                }
                catch (OverflowException)
                {
                    // casting a negative int will cause this exception
                    try
                    {
                        isInt = testNumber.ToInt64(CultureInfo.InvariantCulture) == testNumber.ToDouble(CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        // throw depending on desired behavior
                    }
                }
                catch
                {
                    // throw depending on desired behavior
                }
                return isInt;
            }
    
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
