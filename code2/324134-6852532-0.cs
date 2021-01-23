    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class WizardStepAttribute : Attribute
    {
        public string StepNumber { get; set; }
        public string Name { get; set; }
    }
