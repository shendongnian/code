    [Test, Ignore("Run manually AFTER restarting IIS with 'iisreset' at cmd prompt.")]
    public void CreatingPerformanceCounterBeforeWarmingUpServerThrowsException()
    {
        Console.WriteLine("Given a webserver that is cold");
        Console.WriteLine("When I create a performance counter and read next value");
        using (var pc1 = new PerformanceCounter())
        {
            pc1.CategoryName = @"W3SVC_W3WP";
            pc1.InstanceName = @"_Total";
            pc1.CounterName = @"Requests / Sec";
            Action action1 = () => pc1.NextValue();
            Console.WriteLine("Then InvalidOperationException will be thrown");
            action1.ShouldThrow<InvalidOperationException>();                
        }
    }
    [Test, Ignore("Run manually AFTER restarting IIS with 'iisreset' at cmd prompt.")]
    public void CreatingPerformanceCounterAfterWarmingUpServerDoesNotThrowException()
    {
        Console.WriteLine("Given a webserver that has been Warmed up");
        using (var client = new WebClient())
        {
            client.DownloadString("http://localhost:8082/small1.json");
        }
        Console.WriteLine("When I create a performance counter and read next value");
        using (var pc2 = new PerformanceCounter())
        {
            pc2.CategoryName = @"W3SVC_W3WP";
            pc2.InstanceName = @"_Total";
            pc2.CounterName = @"Requests / Sec";
            float? result = null;
            Action action2 = () => result = pc2.NextValue();
            Console.WriteLine("Then InvalidOperationException will not be thrown");
            action2.ShouldNotThrow();
            Console.WriteLine("And the counter value will be returned");
            result.HasValue.Should().BeTrue();
        }
    }
