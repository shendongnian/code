		/// <summary>
		/// Fires an event and catches any exceptions raised by an event handler.
		/// </summary>
		/// <param name="ev">The event handler to raise</param>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">Event arguments for the event.</param>
		/// <typeparam name="T">The type of the event args.</typeparam>
		public static void Fire<T>(this EventHandler<T> ev, object sender, T e) where T : EventArgs
		{
			if (ev == null)
			{
				return;
			}
			foreach (Delegate del in ev.GetInvocationList())
			{
				try
				{
					ISynchronizeInvoke invoke = del.Target as ISynchronizeInvoke;
					if (invoke != null && invoke.InvokeRequired)
					{
						invoke.Invoke(del, new[] { sender, e });
					}
					else
					{
						del.DynamicInvoke(sender, e);
					}
				}
				catch (TargetInvocationException ex)
				{
					ex.InnerException.PreserveStackTrace();
					throw ex.InnerException;
				}
			}
		}
		/// <summary>
		/// Called on a <see cref="TargetInvocationException"/> to preserve the stack trace that generated the inner exception.
		/// </summary>
		/// <param name="e">The exception to preserve the stack trace of.</param>
		public static void PreserveStackTrace(this Exception e)
		{
			var ctx = new StreamingContext(StreamingContextStates.CrossAppDomain);
			var mgr = new ObjectManager(null, ctx);
			var si = new SerializationInfo(e.GetType(), new FormatterConverter());
			e.GetObjectData(si, ctx);
			mgr.RegisterObject(e, 1, si);
			mgr.DoFixups();
		}
