bool hasToStop = false;
while (true)
            {
                TimeSpan timesp = DateTime.Now - DateTime.Parse(intime.datetime);
                TotalTime = timesp.Hours + " : " + timesp.Minutes + " : " + timesp.Seconds;
                Console.WriteLine(TotalTime); // to see it's working
                await Task.Delay(1000);
                if (hasToStop)
                {
                    Console.WriteLine("Stoped");
                    break;
                }
            }
