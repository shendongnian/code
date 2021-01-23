    public static void SetCloseIEHandler(bool clickOk)
    {
        closeIeHandler = new CloseIEDialogHandler(clickOk);
        BaseIEController.IE.DialogWatcher.Add(closeIeHandler);
    }
    private static void ClearDialogHandler(IDialogHandler dialogHandler)
    {
        if (BaseIEController.IE.DialogWatcher.Contains(dialogHandler))
        {
            BaseIEController.IE.DialogWatcher.Remove(dialogHandler);
            dialogHandler = null;
        }
    }
