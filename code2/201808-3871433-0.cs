		public int? CountQueue(MessageQueue queue, bool isPrivate)
		{
			int? Result = null;
			try
			{
				//MSMQ.MSMQManagement mgmt = new MSMQ.MSMQManagement();
				var mgmt = new MSMQ.MSMQManagementClass();
				try
				{
					String host = queue.MachineName;
					Object hostObject = (Object)host;
					String pathName = (isPrivate) ? queue.FormatName : null;
					Object pathNameObject = (Object)pathName;
					String formatName = (isPrivate) ? null : queue.Path;
					Object formatNameObject = (Object)formatName;
					mgmt.Init(ref hostObject, ref formatNameObject, ref pathNameObject);
					Result = mgmt.MessageCount;
				}
				finally
				{
					mgmt = null;
				}
			}
			catch (Exception exc)
			{
				if (!exc.Message.Equals("Exception from HRESULT: 0xC00E0004", StringComparison.InvariantCultureIgnoreCase))
				{
					if (log.IsErrorEnabled) { log.Error("Error in CountQueue(). Queue was [" + queue.MachineName + "\\" + queue.QueueName + "]", exc); }
				}
				Result = null;
			}
			return Result;
		}
