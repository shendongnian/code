    public class MainClass
    {
        List<DataItem> data; //thousands of DataItem, but each is independent
    
        public void Go()
        {
            data.ForEach(item => ThreadPool.QueueUserWorkItem(s => s.DealWithSelf()));
        }
    }
    
    public class DataItem
    {
        //and a lot of non-thread-safe variables here,variable1 variable2 ...
    
        void DealWithSelf()
        {
            //costs really long time here
            Step1(item);
            Step2(item); //and a lot of StepN(item)
        }
    
        public void StepN(DataItem item)
        {
            //variable1 = blabla
            //variable2 = blabla ..etc
        }
    }
