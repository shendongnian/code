            public static int Main()
            {
                var keys_stream = keys.Publish().RefCount(); // share
    
                IObserver<char> x = new Printer();
                keys_stream.Subscribe(x);
                keys_stream.TakeUntil(b => b == 'z').Wait(); //wait until z
                return 0;
            }
