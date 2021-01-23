            if (BaseIEController.IE.DialogWatcher.Contains(dialogHandler))
            {
                BaseIEController.IE.DialogWatcher.Remove(dialogHandler);
                dialogHandler = null;
            }
        }
