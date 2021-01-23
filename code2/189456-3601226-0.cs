    public static class Extensions
    {
        public static int? ReturnIntegerIfValid(this string potentialInteger)
        {
            try
            {
                int result;
                if (int.TryParse(potentialInteger, out result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
    }
