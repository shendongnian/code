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
