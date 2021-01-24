    var root = new Root();
    root.fulfillmentMessages = new List<Fulfillmentmessage>();
    root.fulfillmentMessages.Add(new Fulfillmentmessage()); // <- Simple response
    root.fulfillmentMessages.Add(new Text()); // <- Text
    root.fulfillmentMessages.Add(new Fulfillmentmessage()); // <- Basic Card
