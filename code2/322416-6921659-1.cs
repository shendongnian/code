            var source = new[] {0, 1, 2, 3, 4}.ToObservable();
            var afterExclusive = source
                .Where(x =>
                           {
                               if (x == 0)
                               {
                                   Console.WriteLine("exclusive");
                                   return false;
                               }
                               return true;
                           })
                .Select(x => new Handled<int> {Data = x})
                .Publish(); // publish is a must otherwise 
            afterExclusive  // we'll get non shared objects
                .Do(x => { x.IsHandled = true; })
                .Subscribe();
            afterExclusive
                .Delay(TimeSpan.FromSeconds(1))
                .Where(x => !x.IsHandled)
                .Subscribe(x => Console.WriteLine("missed by all {0}", x));
            afterExclusive.Connect(); 
