    public interface IPersonDetailsView
    {
        bool PromptUser(string message, string caption);
    }
    // Your form:
    public partial class PersonDetailsForm : Form, IPersonDetailsView
    {
        //...
        public bool PromptUser(string message, string caption) {
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OkCancel);
            return result == DialogResult.Ok;
        }
    }
    // Your business logic:
    public class PersonDetailsController {
        public IPersonDetailsView View { get; set; }
        public void DoingSomething() {
            // ...
            if (this.View.PromptUser(message, caption)) { ...
            }
        }
    }
