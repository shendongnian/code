//register your processor in DI container
services.AddSingleton<MessageProcessor>();
var consumer = new EventingBasicConsumer(Model);
consumer.Received += OnMessageReceived;
Model.BasicConsume(
  queue: queueName,
  autoAck: true,
  consumer: consumer);
//...
private void OnMessageReceived(object sender, BasicDeliverEventArgs e)
{
  var message = e.Body; //here's your message in bytes
  //deserialize into your model
  IFormatter formatter = new BinaryFormatter();
  using (MemoryStream stream = new MemoryStream(obj.Body))
  {
    myMessage = (Message) formatter.Deserialize(stream);
  }
  //...
}
RabbitMQ operates with bytes, not with JSON/XML/...
Can you post your code of Model class and how the connection to Rabbit looks like?
