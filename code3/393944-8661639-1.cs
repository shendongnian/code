    public class TestClass
    {
        public static System.Windows.Controls.Button GlobalButton {get; set;}
        static TestClass()
        {
            GlobalButton = new System.Windows.Controls.Button();
            GlobalButton.Content = "Button1";
        }
    }
