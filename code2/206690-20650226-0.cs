    public class MyWindow : Window {
        private static MyWindow instance;
        public static MyWindow Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyWindow();
                }
                return instance;
            }
        }
    }
