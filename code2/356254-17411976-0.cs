        private void changeStatusMessageMethod(String message)
        {
            if (this.InvokeRequired)
            {
                var changeStatusMessageDelegate = new changeStatusMessage(changeStatusMessageMethod);
                this.Invoke(changeStatusMessageDelegate, new Object[] { message });
            }
            else
            {
                toolstripLabel.Text = message;
            }
        }
        delegate void incrementProgressBar(int value);
        private void incrementProgressBarMethod(int value)
        {
            if (this.InvokeRequired)
            {
                var incrementProgressBarDelegate = new incrementProgressBar(incrementProgressBarMethod);
                this.Invoke(incrementProgressBarDelegate, new Object[] { value });
            }
            else
            {
                toolstripProgress.Increment(value);
            }
        }
