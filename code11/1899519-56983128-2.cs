    byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes("Hello, world!");
    IBasicProperties props = model.CreateBasicProperties();
    props.ContentType = "text/plain";
    props.DeliveryMode = 2;
    props.Headers = new Dictionary<string, object>();
    props.Headers.Add("header",  value);
    model.BasicPublish(exchangeName,
                   routingKey, props,
                   messageBodyBytes);
