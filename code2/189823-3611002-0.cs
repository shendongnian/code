    abstract class Template { 
        ICollection<Statistics> DefaultData;
    }
    class CharacterTemplate : Template { 
        private CharacterTemplate() {
            //appropriate data initialization
        }
        public static Template Instance { get; }
    }
    class Character { 
        Template template = CharacterTemplate.Instance; /* CharacterTemplate */
        ICollection<Statistics> Data ;
    }
