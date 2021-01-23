    public class YourObject {
        public void DoSomething(IMyObject o) {
            // some code here
        }
    }
    YourObject yo = new YourObject();
    MyObject   mo = new MyObject();
    yo.DoSomething(mo); // works
