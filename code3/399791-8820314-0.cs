    public partial class Form1 : Form, IHasErrorProvider {
        public ErrorProvider Provider {
            get { return errorProvider1; }
        }
        // etc..
    }
