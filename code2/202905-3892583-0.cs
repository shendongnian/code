    public class ValueHolder {
        public string SomeInput { get; set; }
        public DialogResult Result { get; set; }
    }
    public class GimmeValues : Form {
        //... HAS A TEXTBOX and Okay Buttons...
        private GimmeValues() {
        }
        public static ValueHolder GetInput(IWin32Window owner) {
            using (GimmeValues values = new GimmeValues) {
                return new ValueHolder { 
                    SomeInput = result.Textbox1.Text,
                    Result = values.ShowDialog(owner)
                };
            }
        }
    }
