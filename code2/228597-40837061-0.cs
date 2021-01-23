		protected override void Dispose(bool disposing)
		{
			if (Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) < 0)
			{
				try
				{
					if (m_NormalImage != null) m_NormalImage.Dispose();
					if (m_DownImage != null) m_DownImage.Dispose();
					if (m_HoverImage != null) m_HoverImage.Dispose();
					m_NormalImage = null;
					m_DownImage = null;
					m_HoverImage = null;
				}
				catch
				{
				}
			}
			base.Dispose(disposing);
		}
