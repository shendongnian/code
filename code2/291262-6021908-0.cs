	private void Run()
	{
		while (true)
		{
			m_WaitHandle.WaitOne();
			Event task = null;
			lock (m_Locker)
			{
				if (m_Tasks.Count == 0)
                                {
					m_WaitHandle.Reset();
					continue;
				}
					
				task = m_Tasks.Dequeue();
			}
			task.DoTask(m_Manager);
		}
	}
