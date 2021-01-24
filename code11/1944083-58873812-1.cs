        [Fact]
        public async Task SimpleTest()
        {
            bool isOK = false;
            Task myTask = new Task(async () =>
            {
                Console.WriteLine("Task.BeforeDelay");
 
                /////remove await
                Task.Delay(1000);
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
  [1]: https://i.stack.imgur.com/z0Bkz.png
