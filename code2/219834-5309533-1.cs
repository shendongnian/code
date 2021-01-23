    [ComVisibleAttribute(true)]
    public class Ofs
    {
       public void MethodA(string msg)
       {
          MessageBox.Show(msg); // hello from js!
       }
    }
    
    public class Form1
    {
      void Form1()
      {
        WebBrowser b = new WebBrowser();
        b.DocumentText = "<script>"
          + "var a = [];"
          + "a.foo = 'bar!'";
          + "var jsFunc=function(y){alert(y);}"
          + "var jsFunc2=function(){return a;}"
          + "window.external.MethodA('hello from js!');</script>";
    
        b.ObjectForScripting = new Ofs(); // we can call any public method in Ofs from js now...
        b.Document.InvokeScript("jsFunc", new string[] { "hello!" }); // we can call the js function
        dynamic a = (dynamic)b.Document.InvokeScript("jsFunc2"); // c#'a' is js'a'
        string x = a.foo;
        MessageBox.Show(x); // bar!
      }
    }
