	public class HashCodeHelper
	{
		public static int CombineOrdered<T>(params T[] objects)
		{
			// System.Web.Util.HashCodeCombiner starts with a seed of 5381 
			int hash = 5381;
			var len = objects.Length;
			// Array.CombineHashCodes: combine max 8 elements
			for (int i = (len >= 8) ? (len - 8) : 0; i < len; i++)
			{
				var obj = objects[i];
				hash = ((hash << 5) + hash) ^ obj.GetHashCode();
			}
			return hash;
		}
	}
	
	var allMessages = new List<Message>()
	{
		// channelId, messageId, text
		new Message(1, 1, "Message1"),
		new Message(1, 2, "Message2"),
		new Message(2, 1, "Message3")
	};
	var lookup = allMessages.ToDictionary(x =>
		HashCodeHelper.CombineOrdered(x.ChannelId, x.MessageId), x => x);
	// to find an entry by (channelId, messageId)
	var hashCode = HashCodeHelper.CombineOrdered(1, 2);
	var myItem = lookup[hashCode];
	// make sure to remove / add an entry from the dict before / after you change it
