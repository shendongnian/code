            Sender _sender = new Sender();
            Receiver _receiver = new Receiver();
            Task<int> getRandomNumber = Task.Factory.StartNew<int>(_sender.GenerateNumber);
            // begin receiving the random number
            getRandomNumber.Start();
            // ... perform other tasks
            // accessing the Result property implicitly waits for the task to complete
            _receiver.TakeRandomNumber(getRandomNumber.Result);
