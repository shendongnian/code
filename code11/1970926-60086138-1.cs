    [Fact]
    public void Sample() {
        var handler = new AssertSynchronousItemHandler();
        var subject = new Subject(handler);
        var input = Enumerable.Range(0, 100).Select(x => new Item(x.ToString())).ToList();
        subject.PerformWork(input);
        // With the code from the question we don't have a way of detecting
        // when `PerformWork` finishes. If we can't change this we need to make
        // sure we wait "long enough". Yes this is yuck. :)
        Thread.Sleep(1000);
        Assert.Equal(input, handler.Items);
    }
