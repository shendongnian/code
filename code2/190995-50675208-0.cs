    const int scheduledPeriodMilliseconds = 20000;
    new Timer(ServiceBusTimerCallback, parameters, 0, scheduledPeriodMilliseconds);
    private static void ServiceBusTimerCallback(object params)
    {
    }
