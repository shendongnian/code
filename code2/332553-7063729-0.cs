    public class MyModel
    {
        public virtual string DecisionReasons { get; set; }
    }
    public class MyViewModel : MyModel
    {
        public string[] DecisionReasonValues { get; set; }
        public override string DecisionReasons
        {
            get
            {
                return string.Join(",", DecisionReasonValues);
            }
            set
            {
                DecisionReasonValues = value.Split(',');
            }
        }
    }
