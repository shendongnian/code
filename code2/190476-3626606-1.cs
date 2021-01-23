    [AttributeUsage(AttributeTargets.Class)]
    public class StartLessThanEndAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var model = (MyModel)value;
            return model.StartDate < model.EndDate;
        }
    }
    [StartLessThanEnd(ErrorMessage = "Start Date must be before the end Date")]
    public class MyModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
