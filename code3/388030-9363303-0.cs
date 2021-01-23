    public class Editable : NotificationObject, IEditableObject
    {
    ...
        public void EndEdit()
        {
                try
                {
                    ...
                }
                catch (Exception e)
                {
                    ExceptionUtils.ThrowOnUIThread(e);
                }
            }
        }
    }
    public static class ExceptionUtils
    {
        public static void ThrowOnUIThread(Exception exception)
        {
            exception.PreserveStackTrace();
            Application.Current.Dispatcher.BeginInvoke(new Action(() => { throw exception; }));
        }
    }
