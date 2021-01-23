    public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
    {
    	var callId = Guid.NewGuid();
    
    	var action = request.Headers.Action.Substring(request.Headers.Action.LastIndexOf('/'));
    	var fileName = string.Format(@"path\{0}_{1}.data", action, callId);
    
    	try
    	{
    		var buffer = request.CreateBufferedCopy(int.MaxValue);
    
    		var writeRequest = buffer.CreateMessage();
    		using (var stream = new FileStream(fileName, FileMode.CreateNew))
    		{
    			using (var writer = XmlDictionaryWriter.CreateBinaryWriter(stream))
    			{
    				writeRequest.WriteMessage(writer);
    				writer.Flush();
    			}
    		}
    
    		request = buffer.CreateMessage();
    		buffer.Close();
    	}
    	catch (Exception ex)
    	{
    		Log.ErrorException("Error writing", ex);
    	}
    
    	Log.Info("Call {0}", callId);
    
    	return callId;
    }
