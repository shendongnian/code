    public class SPEnvironment : IEnvironment
    {
        public static SPEnvironment Instance = new SPEnvironment();
        private SPEnvironment()
        {
            try {
            .....
            }
            finally {
            ......
            }
        }
    }
