	static void Main(string[] args)
	{
		// do something...
		service.Feedback += new FeedbackService.OnFeedback(service_Feedback);
	}
	static StringBuilder sb = new StringBuilder();
	static void service_Feedback(object sender, Feedback feedback)
	{
		sb.AppendLine(string.Format("Feedback - Timestamp: {0} - DeviceId: {1}", feedback.Timestamp, feedback.DeviceToken));
	}
