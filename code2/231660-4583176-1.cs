    public delegate void CallBackA(int i);
    public delegate void CallBackB(string s);
    public class RequestHandler
    {
        public void QueueRequestA(CallBackA callback)
        {
            Task.Factory.StartNew(() =>
                                      {
                                          int ret = 0;
                                          //ret = get stuff of type A from server
                                          callback(ret); //callback is captured here
                                      });
        }
        public void QueueRequestB(CallBackB callback)
        {
            Task.Factory.StartNew(() =>
                                      {
                                          string str = "";
                                          //str = get stuff of typw B from server
                                          callback(str); //callback is captured here
                                      });
        }
    }
