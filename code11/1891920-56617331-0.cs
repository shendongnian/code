    public class BaseLoggableClass
    {    
        public void Debug()
        {
            Debug.Log(ChosenJsonSerializer.Serialize(this));
        }
    }
    public class Result_Splash : BaseLoggableClass
    {
    //... your fields here
    }
    
    // example of usage
    var t = Result_Splash();
    ... some code ...
    t.Debug();
