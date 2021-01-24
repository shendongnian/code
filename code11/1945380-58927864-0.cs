    Private Task<HttpResponseMessage> PersistData()
		{
			Trace.TraceError("test");
			return new Task<HttpResponseMessage>(() => new HttpResponseMessage(HttpStatusCode.Accepted));
		}
