    	public static void SendOnError<T, E>(this IObserver<T> Subject, E ExceptionToSend) where E : Exception
		{
			try { Subject?.OnError(ExceptionToSend); }
			catch (E exception)
			{
				Debug.WriteLine("One or more subscribers to the subject did not implement an OnError handler. Ignoring rethrown exception: " + exception.Message);
			}
		}
