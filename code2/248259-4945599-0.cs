    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Threading;
    
    class Loader : IDisposable {
        private AutoResetEvent initialized = new AutoResetEvent(false);
        private Form loadForm;
        private Rectangle ownerRect;
        private bool closeOkay;
    
        public Loader(Form owner, Form pleaseWait) {
            if (pleaseWait.IsDisposed) throw new InvalidOperationException("Create a *new* form instance");
            loadForm = pleaseWait;
            loadForm.TopMost = true;
            loadForm.ShowInTaskbar = false;
            loadForm.StartPosition = FormStartPosition.Manual;
            ownerRect = new Rectangle(owner.Location, owner.Size);
            loadForm.Load += delegate {
                loadForm.Location = new Point(
                    ownerRect.Left + (ownerRect.Width - loadForm.Width) / 2,
                    ownerRect.Top + (ownerRect.Height - loadForm.Height) / 2);
                initialized.Set();
            };
            loadForm.FormClosing += new FormClosingEventHandler((s, ea) => {
                ea.Cancel = !closeOkay;
            });
            var t = new Thread(() => {
                Application.Run(loadForm);
            });
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
            initialized.WaitOne();
        }
    
        public void Dispose() {
            if (loadForm == null) throw new InvalidOperationException();
            loadForm.Invoke((MethodInvoker)delegate {
                closeOkay = true;
                loadForm.Close(); 
            });
            loadForm = null;
        }
    
    }
