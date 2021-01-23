		[DllImport("user32.dll")]
		static extern short GetKeyState(int key);
		static bool IsKeyPressed(Keys key)
		{
			short state = GetKeyState((int)key);
			return ((state & 128) != 0);
		}
		int i = 0;
		Dictionary<Keys, DateTime> downSince = new Dictionary<Keys, DateTime>();
		private void UpdateKeyStates()
		{
			foreach (var entry in downSince.ToArray())
			{
				if (!IsKeyPressed(entry.Key))
					downSince.Remove(entry.Key);
			}
		}
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			UpdateKeyStates();
			if (!downSince.ContainsKey(e.KeyCode))
			{
				downSince.Add(e.KeyCode, DateTime.UtcNow);
				i++;
			}
			Text = i.ToString() + " " +(int)(DateTime.UtcNow - downSince[e.KeyCode]).TotalMilliseconds;
		}
		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			UpdateKeyStates();
		}
