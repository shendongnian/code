	watcher.EventRecordWritten +=
					new EventHandler<EventRecordWrittenEventArgs>(EventLogEventRead);
	private static readonly object myLock = new object();
	public static async void EventLogEventRead(object obj, EventRecordWrittenEventArgs arg)
	{          
		
		if (arg.EventRecord != null)
		{
			string IP = GetIPFromRecord(arg.EventRecord)
			var json = await new HttpClient().GetStringAsync("https://api.ipgeolocationapi.com/geolocate/" + IP);
			var jsonDeserialized = new JavaScriptSerializer().Deserialize<dynamic>(json);
			string country = jsonDeserialized["name"];
			lock (myLock) {
				Console.WriteLine("IP:\t" + IP);
				Console.WriteLine("Country:\t" + country);
			}
		}
		else
		{	
			lock (myLock) {
				Console.WriteLine("The event instance was null.");
			}
		}
	
	}
