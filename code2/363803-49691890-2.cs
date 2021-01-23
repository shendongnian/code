    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    // do something...
                    return true;
                case Keys.Control |Keys.Alt | Keys.S:
                    // do something...
                    return true;
                case Keys.F2:
                    // do something...
                    return true;
                case Keys.F3:
                    // do something...
                    return true;
                case Keys.F4:
                    // do something...
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
