        [serializable]
        class SomeClass
        {
           public static IsSerializing = false;
           SomeProperty
           {
                set
                {
                     if(IsSerializing) DoYouStuff();
                }
           }
        }
