		void svc_ZOut_GetZOutSummaryCompleted(object sender, ZOut_GetZOutSummaryCompletedEventArgs e)
		{
			svc.ZOut_GetZOutSummaryCompleted -= new EventHandler<ZOut_GetZOutSummaryCompletedEventArgs>(svc_ZOut_GetZOutSummaryCompleted);
			svc = null;
			var whenDone = (Action<bool, ZOutResult>)e.UserState;
			if (e.Error != null)
			{
				FireOnExceptionRaised(e.Error);
				whenDone(false, null);
			}
			else
			{
				var res = e.Result.AllDatesAreUTC();
				FireOnSessionReceived(res.IsError, res.Session);
				if (res.IsError == true)
				{
					whenDone(false, null);
				}
				else
				{
					whenDone(true, res.Result);
				}
			}
		}
