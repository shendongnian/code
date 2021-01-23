            var task = new Task(() => { });
            task.Start();
            if (task.Wait(10000))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
