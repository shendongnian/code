    public sealed class DummyInfoGameWindow : GameWindow
    {
        private DummyInfoGameWindow() {}
        public static DummyInfoGameWindow InitAndGetInfo()
        {
            return new DummyInfoGameWindow();
        }
    }
