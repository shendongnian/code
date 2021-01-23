        public static void ThisWontCompile()
            {
                ActionSurrogate b = (Action a) =>
                {
                    a();
                };
            }
