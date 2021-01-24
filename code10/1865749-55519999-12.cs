    [Serializable]
    public class Character
    {
        // Personal Attributes
        public string firstName;
        public string middleName;
        public string lastName;
        public string fullName;
    
        public bool isMale;
    
        public Character(string _firstName, string _middleName, string _lastName, bool _isMale)
        {
            firstName = _firstName;
            middleName = _middleName;
            lastName = _lastName;
    
            fullName = string.Format("{0} {1} {2}", firstName, middleName, lastName);
    
            isMale = _isMale;
        }
    }
