    public class CustomTimePicker : Xceed.Wpf.Toolkit.TimePicker
    {
        protected override void OnIncrement()
        {
            SetStep();
            base.OnIncrement();
        }
        protected override void OnDecrement()
        {
            SetStep();
            base.OnDecrement();
        }
        private void SetStep()
        {
            Step = CurrentDateTimePart == Xceed.Wpf.Toolkit.DateTimePart.Minute ? 30 : 1;
        }
    }
