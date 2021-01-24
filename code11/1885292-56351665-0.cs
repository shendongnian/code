    public class StepEasingFunction : EasingFunctionBase
    {
        public double NormalizedStep { get; set; }
        protected override Freezable CreateInstanceCore()
        {
            return new StepEasingFunction {NormalizedStep = NormalizedStep};
        }
        protected override double EaseInCore(double normalizedTime)
        {
            var stepIndex = Math.Round(normalizedTime / NormalizedStep);
            return NormalizedStep * stepIndex;
        }
    }
