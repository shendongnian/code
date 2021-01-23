    public class Form1 : Form, IInputValidator {
    
        public void CallBusinessClass() {
            var myObj = new BusinessClass(this); // the key of the concept is here
            myObj.Iterate();
        }
        public bool IsValid(MyClass itemToValidate) {
            return MessageBox.Show("Is valid ?", MessageBoxButtons.YesNo) == MessageBoxButtons.Yes);
        }
    }    
