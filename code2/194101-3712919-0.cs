    if (endpoint.Behaviors.Find<WebHttpBehavior>() != null)
    {
        endpoint.Behaviors.Remove<WebHttpBehavior>();
        WebHttpBehavior2 item = new WebHttpBehavior2();
        // other code omitted
        endpoint.Behaviors.Add(item);
    }
