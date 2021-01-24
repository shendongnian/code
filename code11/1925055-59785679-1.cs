    public interface ISurveyStepResult : ITypeDiscriminator
    {
        string Id { get; set; }
    }
    public class BoolStepResult : ISurveyStepResult
    {
        public string Id { get; set; }
        public string TypeDiscriminator => nameof(BoolStepResult);
        public bool Value { get; set; }
    }
    public class TextStepResult : ISurveyStepResult
    {
        public string Id { get; set; }
        public string TypeDiscriminator => nameof(TextStepResult);
        public string Value { get; set; }
    }
    
    public class StarsStepResult : ISurveyStepResult
    {
        public string Id { get; set; }
        public string TypeDiscriminator => nameof(StarsStepResult);
        public int Value { get; set; }
    }
