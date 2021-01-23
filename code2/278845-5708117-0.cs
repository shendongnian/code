    public static void Dialog<T>(Action<T> action) where T: IDialog, new()
    {
        var d = new T();
        try
        {
            action(d);
        }
        finally
        {
           var idialog = d as IDialog;
           if (idialog != null)
           {
               idialog.Dispose(); // Or whatever IDialog method(s) you want
           }
        }
    }
