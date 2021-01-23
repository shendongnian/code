    public class MyForm : Form {
        public FooComponent OwnedComponent { get; set; }
    }
    public class FooComponent {
        public FooComponent (MyForm OwnerForm) {
            OwnerForm.OwnedComponent = this;
            OwnerForm.FormClosing += MyCallback;
        }
        private void MyCallback(object sender, FormClosingEventArgs e) {
            ...
        }
    }
