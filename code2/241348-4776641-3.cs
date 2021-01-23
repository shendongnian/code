    public interface ISlider
    {
        event CustomEventDelegate CustomEvent;
    }
    public class MyType : ISlider
    {
        public event CustomEventDelegate CustomEvent = delegate { };
    }
