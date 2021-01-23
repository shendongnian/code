    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var counter = 0;
            var ts = new ThreadStart(() =>
                {
                    
                    Foo.Fired += (o, e) =>
                        {
                            counter++;
                        };
                    Foo.InitialiseTimer();
                    Foo.InitialiseTimer();
                });
            var t = new Thread(ts);
            t.Start();
            Thread.Sleep(30);
            Assert.AreEqual(1, counter);
        }
    }
    public class Foo
    {
        private static System.Timers.Timer TheTimer = null;
        public static event EventHandler Fired;
        public static void InitialiseTimer()
        {
            //if (TheTimer != null)
            //{
            //    TheTimer.Stop();
            //    TheTimer = null;
            //}
            TheTimer = new System.Timers.Timer();
            TheTimer.Interval = 10;
            TheTimer.Elapsed += new ElapsedEventHandler(TheTimer_Elapsed);
            TheTimer.AutoReset = false;
            TheTimer.Start();
        }
        public static void TheTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Do stuff in here
            if (Fired != null)
            {
                Fired(null, null);
            }
        }
    }
