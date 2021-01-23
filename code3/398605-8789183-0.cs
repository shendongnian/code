     class MyViewController : UIViewController {
         void PlusOne (string url, string username)
         {
              ThreadPool.QueueUserWorkItem (delegate {
                  var wc = new WebClient ();
                  wc.UploadString (url, "+1");
                  BeginInvokeOnMainThread (delegate { PlusOneDone (username); });
         void PlusOneDone (string username)
         {
               Console.WriteLine ("Plus one completed for {0}", username);
         }
     }
