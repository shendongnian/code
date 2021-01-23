    public class GUIComponent
    {
        object value = null;    // The value linked in
        string label = "";        // The label for the value
        string text = "";         // The label and value appended together
        
        public GUIComponent(string Text, object Value)
        {
            this.text = Text;
            this.value = Value;
        }
        public void Update()
        {
            this.text = this.label + this.value.ToString();
        }
    }
