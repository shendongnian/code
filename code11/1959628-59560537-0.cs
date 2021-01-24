	var consumer = new EventingBasicConsumer(model);
	consumer.Received += (ch, ea) =>
		{
		   try
		   {
				var body = ea.Body;
				var message = Encoding.UTF8.GetString(body);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		};
	channel.BasicConsume(queueName, false, consumer);
