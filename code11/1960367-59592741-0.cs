    public void PrrocessItems()
    {
        IEnumerable<double> numbers = GetNumbers();
        var queue = new Queue<double>();
        Parallel.ForEach(numbers, item => ProcessItem(item, queue));
    }
    private void ProcessItem(double number, Queue<double> queue)
    {
        var computed = Compute(number);
        queue.Enqueue(computed);
    }
