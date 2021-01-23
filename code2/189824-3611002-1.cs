    abstract class Template { 
        ICollection<Statistics> DefaultData;
    }
    class CharacterTemplate : Template { 
        private CharacterTemplate() {
            //appropriate data initialization
        }
        private static readonly CharacterTemplate _instance = new CharacterTemplate();
        public static Template Instance { get { return _instance; } }
    }
    class Character { 
        Template template = CharacterTemplate.Instance; /* CharacterTemplate */
        ICollection<Statistics> Data ;
    }
