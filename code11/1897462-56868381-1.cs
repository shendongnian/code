    public class DerivedKeyBinding : KeyBinding
    {
        ...
        protected override Freezable CreateInstanceCore()
        {
            return new DerivedKeyBinding();
        }
    }
