        public class Test
        {
           private DateTime Epoch { get;set; }
           public long TimeSinceEpoch {
              get {return  Epoch.Ticks; }
              set{ 
                 DateTime temp = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                 Epoch = temp.AddMilliseconds(value);
              } 
            }
        }
