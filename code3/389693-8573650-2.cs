        private void Foo()
        {
            var rand = new Random(DateTime.Now.Millisecond);
            
            for (var i = 0; i < 50; i++)
            {
                Value += rand.Next(1, 10) + "\n";
                System.Threading.Thread.Sleep(500);
            }
        }
