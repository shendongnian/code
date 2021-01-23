    public class ElapsedTime {
        public ElapsedTime(int h, int m) {
            Hours = h;
            Minutes = m;
        }
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public string ElapsedTime {
            get {
                return string.Format("{0}:{1}", Hours, Minutes);
            }
        }
    }
