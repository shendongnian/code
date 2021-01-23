        private void m_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
			m_sync.Post((o) =>
			{
				label1.Text = m_count.ToString();
			}, null);
        }
