    public class callbackdel : EventArgs
    {
        public readonly string resp = null;
        public callbackdel(string s)
        {
            resp = s;
        }
    }    
    public delegate void WorkerEndHandler(object o, callbackdel e);
