    public interface INotification
    {
        void ShowMessage(string message);
    }
    public class MessageBoxNotification : INotification
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
    public class MyClass
    {
        private INotification notification;
        public MyClass(INotification notification)
        {
            this.notification = notification;
        }
        public void SomeFunction(int someValue)
        {
            // Replace with whatever your actual code is...
            ToDate toDate = new SomeOtherClass().SomeOtherFunction(someValue);
            CheckToDate(toDate);
        }
        private void CheckToDate(DateTime ToDate)
        {
            if (Manager.MaxToDate < ToDate.Year)
                notification.Show("toDate, too late!: " + toDate.ToString());
        }
    }
