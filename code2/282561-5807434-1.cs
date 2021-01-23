        public static bool IsReferenceType<T>(T input)
        {
            object surelyBoxed = input;
            return object.ReferenceEquals(surelyBoxed, input);
        }
