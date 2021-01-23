    public interface ICommand {
        void ExecuteOnPreRender(WebControl control, EventArgs args);
    }
    //  This class encapsulates the functionality common
    //  to both OnPreRender commands
    public class SharedPreRenderCommand : ICommand {
        public void ExecuteOnPreRender(WebControl control, EventArgs args) {
            //  Modify the size, border, etc... any property that is 
            //  common to the controls in question
        }
    }
    public class RoleImageButton : ImageButton {
        
        private ICommand onPreRenderCommand = null;
        public void SetPreRenderCommand (ICommand command) {
            onPreRenderCommand = command;
        }
        protected override void OnPreRender(EventArgs args) {
            if (null != onPreRenderCommand) {
                onPreRenderCommand.ExecuteOnPreRender(this, args);
            }
            else {
                base.OnPreRender(args);
            }
        }
    }
    public class RoleButton : Button {
        
        private ICommand onPreRenderCommand = null;
        public void SetPreRenderCommand (ICommand command) {
            onPreRenderCommand = command;
        }
        protected override void OnPreRender(EventArgs args) {
            if (null != onPreRenderCommand) {
                onPreRenderCommand.ExecuteOnPreRender(this, args);
            }
            else {
                base.OnPreRender(args);
            }
        }
    }
