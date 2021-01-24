        static List<HandGesturesStorage> myStogae;
        [HttpPost]
        public ActionResult ReadsSerial(string sintraining)
        {
            if (myStogae == null)
            {
                myStogae = new List<HandGesturesStorage>();
            }
            int st;
            try
            {
                st = Int32.Parse(sintraining);
                myStogae.Add(new HandGesturesStorage(sintraining));
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse '{sintraining}'");
            }
        }
        public class HandGesturesStorage
        {
            public string HandGesture { get; set; }
            public HandGesturesStorage(string sintraining)
            {
                this.HandGesture = sintraining;
            }
        }
