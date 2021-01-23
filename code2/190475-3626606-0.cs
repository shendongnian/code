    public class StartLessThanEndAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var model = (MyModel)value;
            return model.StartDate < model.EndDate;
        }
    }
    [StartLessThanEnd]
    public class MyModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
