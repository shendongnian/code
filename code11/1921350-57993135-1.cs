lang=c#
public class StateObject
{
	// Client socket.  
	public TcpClient workSocket = null;
	// Size of receive buffer.  
	public const int BufferSize = 4096;
	// Receive buffer.  
	public byte[] buffer = new byte[BufferSize];
	// Received data string.  
	public StringBuilder data = new StringBuilder();
	public string responseMessage = "";
}
 public class Client
{
	private StateObject state;
	// Create a new Mutex. The Mutex is when we're writing ore reating the Data of the State Object.
	private static Mutex mut = new Mutex();
	public static ManualResetEvent MessageReceived = new ManualResetEvent(false);
	public StateObject State { get => state; set => state = value; }
	
	private void EndRead(IAsyncResult AR)
	{
		try
		{
			State = (StateObject)AR.AsyncState;
			NetworkStream ns = State.workSocket.GetStream();
			// Get the number of received bytes
			int receivedBytes = ns.EndRead(AR);
			// Connection Closed
			if (receivedBytes == 0)
			{
				return;
			}
			
			if (receivedBytes > 0)
			{
				// Append buffer content to String.    
				mut.WaitOne();
				State.data.Append(Encoding.ASCII.GetString(State.buffer, 0, receivedBytes));
				mut.ReleaseMutex();
				if(State.data.ToString().Contains(MettlerToledo.Message.END_DELIMITER))
				{
					// Copy thread save the content into the Response Message.
					mut.WaitOne();
					State.responseMessage = State.data.ToString();
					mut.ReleaseMutex();
					// Send the signal we got the entire message. So the message can be processed.
					MessageReceived.Set();
				} else
				{
					// Message not yet complete, so we're waiting for more data.
					ns.BeginRead(State.buffer, 0, StateObject.BufferSize, EndRead, state);
				}
			}
		}
		// Catch Exceptions
	}
	
	public void BeginRead()
	{
		Console.WriteLine("Begin Read");
		try
		{
			NetworkStream ns = State.workSocket.GetStream();
			ns.BeginRead(State.buffer, 0, StateObject.BufferSize, EndRead, State);
		}
		catch (SocketException ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
static class Program
{
	[STAThread]
	static void Main()
	{
		Client client = new Client();
		client.Connect("127.0.0.1", 62324);
		
		// F I R S T   R E Q U E S T   -    O N E   R E S P O N S E 
		// Send Request
		client.BeginSend(/* Some XML Request string*/);
		// Start Reading
		client.BeginRead();
		// Waiting for Response
		Client.MessageReceived.WaitOne();
		/* Process the responseMessage
		 * ...
		 */
		// Clear the Processed Data 
		client.State.data.Clear();
		Client.MessageReceived.Reset();
		
		// S E C O N D   R E Q U E S T   -   M U L T I P L E   R E S P O N S E S
		// Send Next Request 
		client.BeginSend(/* Some XML Request string*/);
		// Start Reading again
		client.BeginRead();
		// Waiting for 1. Response
		Client.MessageReceived.WaitOne();
		/* Process the next responseMessage
		 * ...
		 */
		// Clear the Processed Data 
		client.State.data.Clear();
		Client.MessageReceived.Reset();
		
		// Waiting for 2. Response
		client.BeginRead();
		Client.MessageReceived.WaitOne();
		/* Process the next responseMessage
		 * ...
		 */
		// Clear the Processed Data 
		client.State.data.Clear();
		Client.MessageReceived.Reset();
		
		
		// N E X T   R E Q U E S T S 
		// ....
	}
}
