    public class MyViewModel: INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void OnPropertyChanged(string propName) { 
            PropertyChanged?.Invoke(this, new OnPropertyChangedEventArgs(propName)); 
        }
    
        private string textBox1Text;
    
        public string MyFirstTextBox {
            get => textBox1Text;
            set {
                textBox1Text = value;
                OnPropertyChanged(nameof(MyFirstTextBox));
                MySecondTextBox = value; // Set value of second text box
            }
        }
    
        private string textBox2Text;
    
        public string MySecondTextBox {
            get => textBox2Text;
            set {
                textBox2Text = value;
                OnPropertyChanged(nameof(MySecondTextBox));
            }
        }
    
    }
