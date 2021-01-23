    public class Producer
    {
        public event EventHandler OmgIDidSomething;
    }
    
    public class Consumer
    {
        public void AttachTo(Producer producer)
        {
            producer.OmgIDidSomething += new EventHandler(producer_OmgIDidSomething);
        }
    
        private void producer_OmgIDidSomething(object sender, EventArgs e)
        {
            // ...
        }
    }
