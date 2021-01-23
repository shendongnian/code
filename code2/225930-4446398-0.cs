    public class SomeAssessor
    {
        public bool EnabledWhenIdXyz(WebControl control)
        {
            return control.ID == "txtSomething2";
        }
    }
