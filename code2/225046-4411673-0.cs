        public class DoSomthing
        {
            
            public void Do()
            {
                Thread t = new Thread(DoInBackground);
                t.Start();
            }
            public void DoInBackground()
            {
                // ....
            }
        }
