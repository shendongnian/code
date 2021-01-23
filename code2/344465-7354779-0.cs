    public class Base
    {
        private event EventHandler SomeEvent;
        private int initCount = 0;
        public Base()
        {
        }
        protected void OnSomeEvent(object sender, EventArgs e)
        {
            // if from derived constructor EXIT
            switch (initCount)
            {
                case 0:
                    initCount += 1;
                    Console.WriteLine("NO");
                    return;
                case 1:
                    initCount += 1;
                    this.SomeEvent += new EventHandler(OnSomeEvent);
                    Console.WriteLine("NO");
                    return;
            }
            //  else CONTINUE
            Console.Write("YES");
        }
    }
