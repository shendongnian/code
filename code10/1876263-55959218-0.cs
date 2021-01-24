    internal class FormCreationFilter : IMessageFilter
    {
        private List<Form> trackedForms = new List<Form>();
        internal Dictionary<string, Int32> formCounter = new Dictionary<string, Int32>(); // FormName, CloseCount
        public bool PreFilterMessage(ref Message m)
        {
            // Ideally we would trap the WM_Create, butthe message is not routed through
            // the message filter mechanism.  It is sent directly to the window.
            // Therefore use WM_Paint as a surrgogate filter to prevent the lookup logic 
            // from running on each message.
            const Int32 WM_Paint = 0xF;
            if (m.Msg == WM_Paint)
            {
                Form f = Control.FromChildHandle(m.HWnd) as Form;
                if (f != null && !(trackedForms.Contains(f)))
                {
                    trackedForms.Add(f);
                    f.Disposed += IncrementFormDisposed;
                }
            }
            return false;
        }
        private void IncrementFormDisposed(object sender, EventArgs e)
        {
            Form f = sender as Form;
            if (f != null)
            {
                string name = f.GetType().Name;
                if (formCounter.ContainsKey(name))
                {
                    formCounter[name] += 1;
                }
                else
                {
                    formCounter[name] = 1;
                }
                f.Disposed -= IncrementFormDisposed;
                trackedForms.Remove(f);
            }
        }
    }
