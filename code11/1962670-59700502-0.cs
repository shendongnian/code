public abstract class SmsPdu : ITimestamp
{
		// Omitted for brevity 
    
		/// <summary>
		/// Gets the maximum Unicode message text length in characters.
		/// </summary>
		public const int MaxUnicodeTextLength = 70;
        // Omitted for brevity
}
##Possible Workaround
A possible workaround might involve breaking a single message into multiple batches of less than 70 characters and sending multiple to the same destination:
public static IEnumerable<string> BatchMessage(string message, int batchSize = 70)
{
		if (string.IsNullOrEmpty(message))
		{
			// Message is null or empty, handle accordingly
		}
		
		if (batchSize < message.Length)
		{
			// Batch is smaller than message, handle accordingly	
		}
		
        for (var i = 0; i < message.Length; i += batchSize)
		{
            yield return message.Substring(i, Math.Min(batchSize, message.Length - i));
        }
}
And then simply call that prior to sending your message and send the batches individually:
// Open your connection
GsmCommMain comm = new GsmCommMain(4, 19200, 500);
comm.Open();  
			
// Store your destination
var destination = "03319310077";
			
// Batch your message into one or more
var messages = BatchMessage(" کو  ہم نے");
foreach (var message in messages)
{
	// Send each one
	var sms = new SmsSubmitPdu(message, destination, DataCodingScheme.NoClass_16Bit);
	comm.SendMessage(sms);
}
