    public class MyApplication
    {
        public void BusinessMethod(){
            this.Logging("first");
            System.Threading.Thread.Sleep(1000);
            this.Logging("second");
            System.Threading.Thread.Sleep(3000);
            this.Logging("third");
         }
    }
