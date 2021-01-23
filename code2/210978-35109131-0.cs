    public class DelEx
    {
        private delegate void ProcessStuffDelegate(DelEx me);
        private static void ProcessStuffA(DelEx me)
        {
            me.ProcessStuffA();
        }
        private void ProcessStuffA()
        {
            // do tricky A stuff
        }
        private static void ProcessStuffB(DelEx me)
        {
            me.ProcessStuffB();
        }
        private void ProcessStuffB()
        {
            // do tricky B stuff
        }
        private readonly static List<ProcessStuffDelegate> ListOfProcessing = new List<ProcessStuffDelegate>()
        {
            ProcessStuffA,
            ProcessStuffB
            // ProcessStuffC etc
        };
        public DelEx()
        {
            foreach (ProcessStuffDelegate processStuffDelegate in ListOfProcessing)
            {
                processStuffDelegate(this);
            }
        }
    }
