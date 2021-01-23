        public static bool ChangeProperty(Func<Person, string> getter, Action<Person, string> setter, Person person, string value)
        {
            if (!String.IsNullOrEmpty(value) && !getter(person).Equals(value))
            {
                setter(person, value);
                return true;
            }
            return false;
        }
