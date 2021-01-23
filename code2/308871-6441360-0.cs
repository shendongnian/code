    public class MyBinding : Binding
    {
        private object value;
        
        public object Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.Source = value;
            }
        }
    }
