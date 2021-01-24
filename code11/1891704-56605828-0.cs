    abstract class Test
    {
        public static Test RunMachine()
        {
            return new SpecializedTest();
        }
    }
    class SpecializedTest : Test {}
