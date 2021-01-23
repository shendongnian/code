    internal static class HashHelper
    {
        private static int InitialHash = 17; // Prime number
        private static int Multiplier = 23; // Different prime number
        public static Int32 GetHashCode(params object[] values)
        {
            unchecked // overflow is fine
            {
                int hash = InitialHash;
                if (values != null)
                    for (int i = 0; i < values.Length; i++)
                    {
                        object currentValue = values[i];
                        hash = hash * Multiplier
                            + (currentValue != null ? currentValue.GetHashCode() : 0);
                    }
                return hash;
            }
        }
    }
