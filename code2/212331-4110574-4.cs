    public partial class MyForm : Form, ISerializable {
    
        public MyForm() {}
        public MyForm(SerializationInfo info, StreamingContext context) : base() {
            foreach (Control control in Controls) {
                control.Text = info.GetString(control.Name);
            }
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            
            foreach (Control control in Controls) {
                info.AddValue(control.Name, control.Text);
            }
        }
    }
