    public class PropertyValueRejectedEventArgs {
        public string PropertyName { get; set; }
        public object RejectedValue { get; set; }
    }
    public class MyClass {
        public event EventHandler<PropertyValueRejectedEventArgs> PropertyRejected;
        
        private int _grade = -1;
        public int Grade {
            get { return _grade; }
            set {
                if (value >= this.lowerLimit) {
                    _grade = value;
                } 
                else if (PropertyRejected != null) {     
                    PropertyRejected(
                        this, 
                        new PropertyValueRejectedEventArgs {
                            PropertyName = "Grade",
                            RejectedValue = value
                        }
                    ); 
                }                
            }
        }
    }
