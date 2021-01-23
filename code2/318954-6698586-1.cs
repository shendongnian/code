			string tts1 = "tts1.mp3";
			string tts2 = "tts2.mp3";
			FileStream fs1 = null;
			FileStream fs2 = null;
			try
			{
				fs1 = File.Open(tts1, FileMode.Append);
				fs2 = File.Open(tts2, FileMode.Open);
				byte[] fs2Content = new byte[fs2.Length];
				fs2.Read(fs2Content, 0, (int)fs2.Length);
				fs1.Write(fs2Content, 0, (int)fs2.Length);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + " : " + ex.StackTrace);
			}
			finally
			{
				fs1.Close();
				fs2.Close();
			}
