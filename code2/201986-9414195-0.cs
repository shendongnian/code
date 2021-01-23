			catch (Exception ex)
			{
				//byte[] buffer = new byte[999999];
				WebException wex = (WebException)ex;
				var s = wex.Response.GetResponseStream();
				string ss = "";
				int lastNum = 0;
				do
				{
					lastNum = s.ReadByte();
					ss += (char)lastNum;
				} while (lastNum != -1);
				s.Close();
				s = null;
				ErrorHasOccurred(new Exception("An error has occurred sending the notification to Urban Airship. Please see the InnerException for details. Please note that, for sending messages, the master password is required (instead of the regular password). ERROR: " + ss, ex));
			}
