    public void DoProcessing()
    {
        for (int i = 0; i < 100000; i++)
        {
            ProcessItem();
        }
    }
    private void ProcessItem()
    {
        TestObj testc = new TestObj
        {
            myTest = "testing asdf"
        };
    }
    public class TestObj
    {
        public string myTest;
    }
    
