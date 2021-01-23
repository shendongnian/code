    public interface IHaveAValueYouNeed 
    {
        string ValueGetter();
        event EventArgs ValueChanged;
    }
    
    public class GUIComponent
    {
        public delegate string ValueGetter();
    
        ValueGetter getter;    // The value linked in
        string label = "";        // The label for the value
        string text = "";         // The label and value appended together
    
        public GUIComponent(string Text, IHaveAValueYouNeed getter)
        {
            this.text = Text;
            this.getter += getter.ValueGetter;
            getter.ValueChanged += ValueUpdatedHandler;
        }
    
        public void Update()
        {
            this.text = this.label + this.value();
        }
    
        public void ValueUpdatedHandler(object sender, EventArgs e)
        {
            Update();
        }
    }
