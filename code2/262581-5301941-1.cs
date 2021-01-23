        internal delegate void AppendExceptionDelegate(Exception e);
		public void AppendException(Exception e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new AppendExceptionDelegate(AppendException), new[] { e });
			}
			else
			{
				this._textBox.Text += e.Message;
			}
		}
