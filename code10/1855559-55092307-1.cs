    public class CB : ComboBox
    {
        public event Action<CB> ControlEnterPressed;
        protected virtual void OnControlEnterPressed()
        {
            ControlEnterPressed?.Invoke(this);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            System.Diagnostics.Debug.Print(keyData.ToString());
            // runs before ProcessDialogKey, ProcessDialogKey is called if this method returns false
            bool ret = false;
            if (keyData.HasFlag(Keys.Control) && (keyData.HasFlag(Keys.Return) || keyData.HasFlag(Keys.Enter)))
            {
                BeginInvoke(new Action(OnControlEnterPressed)); //let message processing finish before raising the event
                ret = true;   // indicate key handled
            }
            else
            {
                ret = base.ProcessCmdKey(ref msg, keyData);
            }
            return ret;
        }
    }
