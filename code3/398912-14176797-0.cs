    public abstract class FormExtenderClass : Form{
        private bool formClosingFired = false;
        private bool formClosedFired = false;
        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            formClosingFired = !e.Cancel;
        }
        protected override void OnFormClosed(FormClosedEventArgs e) {
            base.OnFormClosed(e);
            formClosingFired = true;
        }
        protected override void Dispose(bool disposing) {
            if (!formClosingFired) OnFormClosing(new FormClosingEventArgs(CloseReason.UserClosing, false));
            if (!formClosedFired) OnFormClosed(new FormClosedEventArgs(CloseReason.UserClosing));
            base.Dispose(disposing);
        }
    }
