    public partial class Test: ITestView
    {
         public event EventHandler OnSomeEvent;
         public event EventHandler OnAnotherEvent;
        private void StkQuit()
        {
            _stkApplicationUi.OnQuit -= StkQuit;
            Marshal.FinalReleaseComObject(_stkApplicationUi);
            if (this.OnSomeEvent != null)
            {
                this.OnSomeEvent(this, EventArgs.Empty);
            }
            Application.Exit();
        }
    }
