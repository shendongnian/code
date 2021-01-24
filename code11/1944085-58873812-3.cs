 [Fact]
        public async Task SimpleTest()
        {
            bool isOK = false;
            Task myTask = new Task(() =>
            {
                Console.WriteLine("Task.BeforeDelay");
                Task.Delay(3000).Wait();
                Console.WriteLine("Task.AfterDelay");
                isOK = true;
                Console.WriteLine("Task.Ended");
            });
            Console.WriteLine("Main.BeforeStart");
            myTask.Start();
            Console.WriteLine("Main.AfterStart");
            await myTask;
            Console.WriteLine("Main.AfterAwait");
            Assert.True(isOK, "OK");
        }
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/XZkiJ.png
