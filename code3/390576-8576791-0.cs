    public class SnappySlider : Slider
    {
        public SnappySlider()
        {
            this.DefaultStyleKey = typeof(Slider);
        }
        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);
            Value = Value < 0.5 ? 0 : 1;
        }
    }
