    private static void Test(IQueryable<SomeClass> data)
        {
            var minDate = DateTime.MinValue;
            var avgMilliseconds = data.Select(x => x.SomeDateField.Subtract(minDate).TotalMilliseconds).Average();
            var avgDate = minDate.AddMilliseconds(avgMilliseconds);
            Console.WriteLine(avgMilliseconds);
            Console.WriteLine(avgDate);
        }
