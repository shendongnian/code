c#
static void Main(string[] args)
{
	// Create queue
	string queueName = "computer_name\\private$\\test queue";
	MessageQueue.Create(queueName);
	// Create MessageQueue object and enable journal
	MessageQueue queue = new MessageQueue(queueName);
	queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
	queue.UseJournalQueue = true;
	Console.WriteLine($"queue.CanRead = {queue.CanRead}");
	Console.WriteLine($"queue.CanWrite = {queue.CanWrite}");
	// Send message
	queue.Send("test message");
	// Receive message from queue
	// The message is copied to the journal now
	Console.WriteLine($"queue.Receive(): {(string)queue.Receive().Body}");
	// Receive message again from journal
	MessageQueue journal = new MessageQueue(queueName + "\\Journal$");
	journal.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
	Console.WriteLine($"journal.CanRead = {journal.CanRead}");
	Console.WriteLine($"journal.CanWrite = {journal.CanWrite}");
	Console.WriteLine($"journal.Receive(): {(string)journal.Receive().Body}");
}
This will create a new message queue and enable the matching journal queue. A sent message is stored in the message queue; after receiving it, it is moved to the journal queue. You can then receive this message a second time from the journal queue.
The program's output is:
queue.CanRead = True
queue.CanWrite = True
queue.Receive(): test message
journal.CanRead = True
journal.CanWrite = False
journal.Receive(): test message
