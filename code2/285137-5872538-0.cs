       protected void setTransactionButton(Boolean enabled)
        {
            (new Task(() =>
            {
                transcriptQuitButton.Enabled = enabled;
            })).Start(uiScheduler);
        }
