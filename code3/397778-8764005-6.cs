            Sender _sender = new Sender();
            Receiver _receiver = new Receiver();
            Task<int> getRandomNumber = Task.Factory.StartNew<int>(_sender.GenerateNumber);
            // begin receiving the random number
            getRandomNumber.Start();
            // ... perform other tasks
            // wait for up to 5 seconds for the getRandomNumber task to complete
            if (getRandomNumber.Wait(5000))
            {
                _receiver.TakeRandomNumber(getRandomNumber.Result);
            }
            else
            {
                // the getRandomNumber task did not complete within the specified timeout
                System.Console.WriteLine("Timeout");
            }
