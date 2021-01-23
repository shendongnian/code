    public class SomeOtherClass
    {
        private readonly GameProperties _properties;
        public SomeOtherClass(GameProperties properties)
        {
            _properties = properties;
        }
        public void Foo()
        {
            int speed = _properties.GameSpeed;
        }
    }
