    namespace MyNamespace
    {
      public partial class MyDialog : Window
      {
        public MyDialog(ExcelReference sheetReference)
          {
            this.LoadViewFromUri("/MyApp;component/mynamespace/mydialog.xaml");
          }
      }
    }
