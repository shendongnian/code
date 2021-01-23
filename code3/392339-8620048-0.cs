            public void Work(object dict) {
                var rnd = new Random();
                Console.WriteLine((dict as Dictionary<Guid, Guid>).Count);
                for (int i = 0; i < 1000000; i++) {
                    (dict as Dictionary<Guid, Guid>)[Guid.NewGuid()] = Guid.NewGuid();
                    for (int ix = 0; ix < rnd.Next(1000); ++ix) ;   // NOTE: random delay
                }
            }
