    public class MyMessageBox
    {
       public static MyResult Show(params)
       {
           var myMessageBox = new MyMessageBox();
           myMessageBox.Message = params ...
           return  myMessageBox.ShowDialog();
       }
    }
