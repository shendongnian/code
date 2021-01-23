            var o = e.ToObservable().Publish();
            var onOff = o
                .Where(x => x.StartsWith("Transition"))
                .Select(x => x.EndsWith("Good"))
                .StartWith(true);
            var goods = o
                .AndOn(onOff)
                .Where(x => !x.StartsWith("Transition"));
            using (goods.Subscribe(Console.WriteLine))
            using (o.Connect())
            {
                Console.ReadKey();
            }
