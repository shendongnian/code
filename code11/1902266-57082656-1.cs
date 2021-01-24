 		public class RearrangeMessagesInArray
		{
			public void RearrangeMessagesInArrays(Message[] today, Message[] week, Message[] earlier)
			{
				// To work with linQ, convert array to list.
				var earlierAsList = earlier.ToList();
				// Add all messages to "earlier" - array, when its older then 7 days
				earlierAsList.ToList().AddRange(GetAllMessagesForGivenArrayAndTime(today, Times.Earlier));
				earlierAsList.ToList().AddRange(GetAllMessagesForGivenArrayAndTime(week, Times.Earlier));
				//return to "earlier" - array.
				earlier = earlierAsList.ToArray();
				// Add all messages to "week"-array, which is older than one day and newer than 7 days and remove all which is over 7 days
				week = GetAllMessagesForGivenArrayAndTime(week, Times.Week).ToArray();
				// Reassign "today"-array without messages, which are older than 1 one day.
				today = GetAllMessagesForGivenArrayAndTime(today, Times.Day).ToArray();
				PrintOutArrayAsJson(today, week, earlier);
			}
			private void PrintOutArrayAsJson(Message[] today, Message[] week, Message[] earlier)
			{
				today.ToList().ForEach(message => Console.WriteLine(WriteFromObject(message)));
				week.ToList().ForEach(message => Console.WriteLine(WriteFromObject(message)));
				earlier.ToList().ForEach(message => Console.WriteLine(WriteFromObject(message)));
			}
			private IEnumerable<Message> GetAllMessagesForGivenArrayAndTime(Message[] messages, Times time )
			{
				switch (time)
				{
					case Times.Day:
						return from message in messages
							where GetDaysDiffBetweenNowAndGivenDate(message.ReceivedTime) <= 1
							select message;
					case Times.Week:
						return from message in messages
							where GetDaysDiffBetweenNowAndGivenDate(message.ReceivedTime) <= 7 
								  && GetDaysDiffBetweenNowAndGivenDate(message.ReceivedTime) > 1
							   select message;
					case Times.Earlier:
						return from message in messages
							where GetDaysDiffBetweenNowAndGivenDate(message.ReceivedTime) > 7
							select message;
					default:
						return null;
				}
			}
			private int GetDaysDiffBetweenNowAndGivenDate(DateTime givenDateTime)
			{
				return (DateTime.Today - givenDateTime).Days;
			}
			public class Message
			{
				public string ReceivedMessage { get; set; }
				public DateTime ReceivedTime { get; set; }
				public string SentBy { get; set; }
			}
			private enum Times { Day, Week, Earlier};
			// Create a User object and serialize it to a JSON stream.  
			public string WriteFromObject(Message message)
			{
				// Create a stream to serialize the object to.  
				var ms = new MemoryStream();
				// Serializer the User object to the stream.  
				var ser = new DataContractJsonSerializer(typeof(Message));
				ser.WriteObject(ms, message);
				byte[] json = ms.ToArray();
				ms.Close();
				return Encoding.UTF8.GetString(json, 0, json.Length);
			}
		}
