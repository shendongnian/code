        [Test]
        public void TestDateTime() {
            var start = DateTime.Now.Date;
            var end = DateTime.Now.Date.AddDays(35);
            var workdays = (end - start).Days - ((end - start).Days/7)*2 
                - (((end - start).Days%7==0)?0:(((int)start.DayOfWeek==0)?1:Math.Max(Math.Min((int)start.DayOfWeek + (end - start).Days%7 - 6, 2), 0)));
            new []{DateTime.Now.AddDays(19), DateTime.Now.AddDays(20)}.ToList().ForEach(
                x => { if (x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday) workdays--; });
            Console.Out.WriteLine("workdays = {0}", workdays);
        }
