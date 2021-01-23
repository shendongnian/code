    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var myComObj = new MyComObject();
    
            myComObj.OnEvent += ObjectEvt;
    
            Thread.CurrentThread.Join(); // Waits forever
        }
    
        static void ObjectEvt(object sender, EventArgs e) { }
    }
