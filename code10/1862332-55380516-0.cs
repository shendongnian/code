    cfg.UseMessageScheduler(new Uri("rabbitmq://localhost/quartz"));
    cfg.ReceiveEndpoint(host, "submit-order", e =>
    {
        e.UseScheduledRedelivery(r => r.Intervals(TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(15), TimeSpan.FromMinutes(30)));
        e.UseMessageRetry(r => r.Immediate(5));
        e.Consumer(() => new SubmitOrderConsumer(sessionFactory));
    });
