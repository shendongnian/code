     public class Timer
        {
            public int Seconds => timeSpan.Seconds;
    
            public int Minutes => timeSpan.Minutes;
    
            public int Hours => timeSpan.Hours;
    
            private TimeSpan timeSpan;
    
            public void Update(double timeMultiplier, double deltaTime)
            {
                timeSpan = timeSpan.Add(TimeSpan.FromSeconds(timeMultiplier * deltaTime));
    
                Console.WriteLine(timeSpan.ToString(@"hh\:mm\:ss"));
            }
        }
