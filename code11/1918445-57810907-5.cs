    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    
    class Program
    {
        static void Main()
        {
            const string fileName = @"numbers.txt";
            using (var writer = new StreamWriter(fileName))
            {
                var random = new Random();
                for (var i = 0; i < 10000; i++)
                    writer.WriteLine(random.Next(100));
                writer.Close();
            }
    
            var sw = new Stopwatch();
    
            var pq = new PriorityQueue<int>();
            var numbers = File.ReadAllLines(fileName);
            foreach (var number in numbers)
                pq.Enqueue(Convert.ToInt32(number));
    
            long total = 0;
            sw.Start();
            while (pq.Count() > 0)
            {
                // get two smallest numbers when the priority queue is not empty
                int sum = (pq.Count() > 0 ? pq.Dequeue() : 0) + (pq.Count() > 0 ? pq.Dequeue() : 0);
                total += sum;
                // put the sum of two smallest numbers in the priority queue if the queue is not empty
                if (pq.Count() > 0) pq.Enqueue(sum);
            }
            sw.Stop();
            Console.WriteLine($"Total = {total}");
            Console.WriteLine($"Time = {sw.Elapsed.TotalMilliseconds}");
    
            total = 0;
            var query = File.ReadAllLines(fileName).Select(x => Convert.ToInt32(x));
            sw.Restart();
            while (query.Count() > 0)
            {
                // sort the numbers
                var sorted = query.OrderBy(x => x).ToList();
                // get sum of the first two smallest numbers
                var sumTwoSmallest = sorted.Take(2).Sum();
                // count total
                total += sumTwoSmallest;
                // remove the first two smallest numbers
                query = sorted.Skip(2);
                // add the sum of the two smallest numbers into the numbers
                if (query.Count() > 0)
                    query = query.Append(sumTwoSmallest);
            }
            sw.Stop();
            Console.WriteLine($"Total = {total}");
            Console.WriteLine($"Time = {sw.Elapsed.TotalMilliseconds}");
    
            Console.WriteLine("Press any key...");
            Console.ReadKey(true);
        }
    }
