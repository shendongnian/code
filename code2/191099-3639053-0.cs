    public interface IMyInterface {
        void MyAction();
    }
    public partial class form1 : Form, IMyInterface {
        public void MyAction() {
            richTextBox1.Text = "first click";
            ...
        }
    }
    public class button1 : Button {
        protected override void OnClick(EventArgs e) {
            var parent = this.Parent as IMyInterface;
            if( parent != null ) {
                parent.MyAction();
            }
        }
    }
