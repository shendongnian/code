    namespace SpaceName
    {
        public class SpaceMine
        {
        
        }
        
        public class Ability
        {
            public class SpaceMine :  Ability
            {
                void Foo()
                {
                    Ability.SpaceMine nestedMine; //Nested
                    //Ability is reducant but it improves readability a little
                    SpaceName.SpaceMine globalMine; //Not nested
                }
            }
        }
    }
