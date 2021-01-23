            public static bool operator ==( MoneyType a, MoneyType b)
            {
                return a.cents == b.cents;
            }
            public static bool operator !=(MoneyType a, MoneyType b)
            {
                return a.cents != b.cents;
            }
