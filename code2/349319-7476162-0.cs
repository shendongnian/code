    public void setNumber(int num) {
        if (Monitor.TryEnter(locker)) {
            // etc..
        }
        else Console.WriteLine("Number {0} will never make it to the consumer", num);
    }
