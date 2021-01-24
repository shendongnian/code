c#
try
{
    StateObject state = (StateObject) ar.AsyncState;
	Socket client = state.workSocket;
	int bytesRead = client.EndReceive(ar);
	if (bytesRead > 0)
	{
		stream.Write(state.buffer, 0, bytesRead);
		client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(BeginDictionaryRecieve), state);
	}
	else
	{
		if (stream.Length > 1)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			stream.Position = 0;
			this.recievedListForRackDisplay =(List<string>)formatter.Deserialize(stream);
			OnDataRecieved.Invoke();
			client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
							new AsyncCallback(BeginDictionaryRecieve), state);
		}
	}
}
catch (Exception e)
{
    throw e;
}
It should also be noted that this solution only works if the client Socket is disposed of after sending its data. 
