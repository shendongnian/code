    public interface IChildHost {
        void UpdateStatusBar(string status);
        //Other methods & properties
    }
    public partial class ParentForm : IChildHost {
        public void UpdateStatusBar(string status) {
            ...
        }
        //Implement other methods & properties
    }
    public partial class ChildForm {
        readonly IChildHost host;
        public ChildForm(IChildHost parent) {
            this.host = parent;
        }
    }
