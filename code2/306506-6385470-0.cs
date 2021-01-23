            string output = "";
            {
                DateTime startTime1 = DateTime.Now;
                myclass cls = new myclass();
                for (int i = 0; i < 100000000; i++)
                {
                    cls = new myclass();
                    cls.var1 = 1;
                }
                TimeSpan span1 = DateTime.Now - startTime1;
                output += span1.ToString();
            }
            {
                DateTime startTime2 = DateTime.Now;
                for (int i = 0; i < 100000000; i++)
                {
                    myclass cls = new myclass();
                    cls.var1 = 1;
                }
                TimeSpan span2 = DateTime.Now - startTime2;
                output += Environment.NewLine + span2.ToString() ;
            }
            //Span1 took 00:00:02.0391166
            //Span2 took 00:00:01.9331106
    public class myclass
    {
        public int var1 = 0;
        public myclass()
        {
        }
    }
