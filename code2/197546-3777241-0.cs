    public interface IFormField
    {
        string Name { get; set; }
        object Value { get; set; }
    }
    public class FormField<T> : IFormField
    {
        private Form Form;
        public T Value { get; set; }
        public string Name { get; set; }
    
        public void Process()
        {
            // do something
        }
    
        public FormField(Form form, string name, T value)
        {
            this.Name = name;
            this.Value = value;
            this.Form = form;
        }
        // Explicit implementation of IFormField.Value
        object IFormField.Value
        {
            get { return this.Value; }
            set { this.Value = (T)value; }
        }
    }
