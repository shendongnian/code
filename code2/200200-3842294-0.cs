    delegate bool CommandKeyPressHandler(object sender, Keys keyData);
    
    class CustomDataGridView : DataGridView
    {
        public event CommandKeyPressHandler CommandKeyPress;
    
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            CommandKeyPressHandler eventDelegate = CommandKeyPress;
            if (eventDelegate != null)
            {
                foreach (CommandKeyPressHandler handler in eventDelegate.GetInvocationList())
                {
                    if (handler(this, keyData))
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
