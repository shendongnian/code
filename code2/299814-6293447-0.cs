    [ComVisible(true)]
    public class MyClass
    {
       // can be called from JavaScript
       public void ShowMessageBox(string msg){
           MessageBox.Show(msg);
       }
    }
    myBrowser.ObjectForScripting = new MyClass(); 
    // or you can reuse instance of MyClass
