    [Serializable]
    public class ErrorAspectAttribute : OnMethodBoundaryAspect {
        private bool Notify;
        public ErrorAspectAttribute(bool notifyUser = true) {
            this.Notify = notifyUser;
        }
        public override void OnException(MethodExecutionEventArgs args) {
            ErrorLoggerUtil.LogException(args.Exception);           
            if (Notify)
                MessageBox.Show("An error has occurred.  Please save blah blah blah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            args.FlowBehavior = FlowBehavior.Return;
        }
    }
