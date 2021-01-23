    public class MyClass
    {
        public static ListView MyListView { get; set; }
        public static void LogMethod(string level, string message)
        {
            Console.WriteLine("l: {0} m: {1}", level, message);
            var logListView = MyListView;
            if (logListView != null) {
                logListView.Items.Add(Message);
            }
            // Do some other actions
        }
    }
