    using System;
    using System.Windows;
    namespace AccessObjectFromEventHandler
    {
        public partial class MainWindow : Window
        {
            ExternalClass externalClass;
            public MainWindow()
            {
                InitializeComponent();
                externalClass = new ExternalClass();
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Console.WriteLine($"Button Click Event Fired.");
                externalClass.Name = "Some Name";
                externalClass.ExternalClassMethod();
            }
        }
        public partial class ExternalClass
        {
            public string Name { get; set; }
            //  The access modifier is "public" to enable access from external types.
            public void ExternalClassMethod()
            {
                Console.WriteLine($"ExternalClassMethod executed.  Name = {Name}");
            }
         }
    }
