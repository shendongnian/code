    [CreateAssetMenu]
    [Serializable]
    public class Character : Scriptable Object
    {
        // Attributes
        public string firstName;
        public string middleName;
        public string lastName;
        public string fullName;
        public bool isMale;
    
        // Constructor
        private void Init(string _firstName, string _middleName, string _lastName, bool _isMale)
        {
            firstName = _firstName;
            middleName = _middleName;
            lastName = _lastName;
    
            // All The Functions 
            fullName = string.Format("{0} {1} {2}", firstName, middleName, lastName);
    
            isMale = _isMale;
    
            // and all the other functions like date calculator.
        }
    
        public static Character CreateCharacter(string firstName, string middleName, string lastName, bool isMale)
        {
            var character = ScriptableObject.CreateInstance<Character>();
    
            character.Init(firstName, middleName, lastName, isMale);
        }
    }
    
