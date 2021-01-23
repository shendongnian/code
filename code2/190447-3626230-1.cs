    private void InitUIState(ViewMode mode)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                InitUIState(mode);
            });
        }
        else
        {
            this.labelProgramStatus.Text = CONSOLE_IDLE_STATUS;
        }
    }
