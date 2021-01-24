    /// <summary>
    /// Gives the option to retry if the provided action throws an exception
    /// </summary>
    /// <param name="action">The action to perform</param>
    public void RetryableAction(Action action) {
        while (true) {
            try {
                action();
                break;
            } catch (Exception e) {
                var dr = DialogResult.Retry;
                Invoke((MethodInvoker) (() => dr = MessageBox.Show(this,
                    $"There was an error:\r\n{e.Message}\r\n\r\nDo you want to retry?", "Error",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)));
                if (dr == DialogResult.Cancel) {
                    throw;
                }
            }
        }
    }
    public async Task RetryableAction(Func<Task> action) {
        while (true) {
            try {
                await action();
                break;
            } catch (Exception e) {
                var dr = DialogResult.Retry;
                Invoke((MethodInvoker)(() => dr = MessageBox.Show(this,
                    $"There was an error:\r\n{e.Message}\r\n\r\nDo you want to retry?", "Error",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)));
                if (dr == DialogResult.Cancel) {
                    throw;
                }
            }
        }
    }
