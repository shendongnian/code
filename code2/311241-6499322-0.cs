    public enum InputType
    {
        Text,
        Number,
        Password
    }
    
    public class Value
    {
        public object Value { get; set;}
        public InputType InputType { get; set;}
    }
    
    public abstract class MyBaseClass
    {
        public Dictionary<string, Value> fields;
    }
    
    public class StackOverflow : MyBaseClass 
    {
       public StackOverflow()
       {
           fields.Add("Username", new Value() {
               Value = "Default Username",
               InputType = InputType.Text
           });
           fields.Add("Password", new Value() {
               Value = "hw78fksm9",
               InputType = InputType.Password
           });
       }
    }
