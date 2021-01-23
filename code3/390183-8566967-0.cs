    public class Baby : Parent
    {
        private readonly FieldInfo _ageField = typeof(Parent).GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);
        public int newAge
        {
            get
            {
                return (int)_ageField.GetValue(this);
            }
            set
            {
                _ageField.SetValue(this, value);
            }
        }
    } 
