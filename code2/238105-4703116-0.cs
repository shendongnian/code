            System.Collections.Generic.List<MyObject> collection = new List<MyObject>();
            MyObject mb = new MyObject();
            mb.TheDuration = new TimeSpan(100000);
            collection.Add(mb);
            mb.TheDuration = new TimeSpan(100000);
            collection.Add(mb);
            mb.TheDuration = new TimeSpan(100000);
            collection.Add(mb);
            var sum = (from r in collection select r.TheDuration.Ticks).Sum();
            Console.WriteLine( sum.ToString());
            //here we have new timespan that is sum of all time spans
            TimeSpan sumedup = new TimeSpan(sum);
        public class MyObject {public  TimeSpan TheDuration {get;set;} }
