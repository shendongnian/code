    ConfirmDialogHandler confirmHandler = new ConfirmDialogHandler();
            using (new UseDialogOnce(browser.DialogWatcher, confirmHandler))
            {
                confirmHandler.WaitUntilExists();
                confirmHandler.CancelButton.Click();
            }
