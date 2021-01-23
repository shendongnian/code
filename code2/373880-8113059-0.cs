        [Serializable]
        public class Settings {
            [NonSerialized]
            private CheckIntervalChanged checkIntervalChangedBacking;
            public event CheckIntervalChanged CheckIntervalChanged {
                add { checkIntervalChangedBacking += value; }
                remove { checkIntervalChangedBacking -= value; }
            }
            // etc..
        }
