    private static readonly Container container;
    
    static Program()
    {
        container = new Container();
        container.Register<IFooMetrics, MetricCounter >();
        
        container.Verify();
    }
