        public static void MyEnumMethod(Enum e)
        {
            var enumValues = Enum.GetValues(e.GetType());
            // you can iterate over enumValues with foreach
        }
