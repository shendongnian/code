            var o = e.ToObservable().Publish();
            var gb = o.Where(x => x == "Transition Good->Bad");
            var bg = o.Where(x => x == "Transition Bad->Good").Publish("");
            var goods =
                from s in o
                join g in bg on Observable.Empty<string>() equals gb
                where !s.StartsWith("Transition")
                select s;
            using (goods.Subscribe(Console.WriteLine))
            using (bg.Connect())
            using (o.Connect())
            {
                Console.ReadKey();
            }
