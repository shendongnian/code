    private void Listener_EventWritten(object sender, EventWrittenEventArgs e)
		{
			foreach (object payload in e.Payload)
			{
				Log.Logger.Information($"[{e.EventName}] {e.Message} | {payload}");
			}
		}
