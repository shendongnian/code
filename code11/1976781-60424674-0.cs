	var messageTrack = new Subject<MessageEventArgs>();
	
	var query =
		from e in messageTrack
		where !mMessages.Contains(e.Message)
		select $"Message|{e.Time}|{e.Text}";
	
	query.Throttle(TimeSpan.FromMilliseconds(X)).Subscribe(Console.WriteLine);
