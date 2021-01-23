    		#region Form
		private void frmLoader_Load(object sender, EventArgs e)
		{
						if (OnExecute != null)
			{
				OnExecute(this, null);
			}
		}
		#endregion
		#region "Public"
		public void OnInitialize(object sender, EventArgs<String, int> e)
    {
      if (pbLoader.InvokeRequired)
      {
        pbLoader.Invoke(new Action<object, EventArgs<String, int>>(OnInitialize), new Object[] { sender, e });
      }
      else
      {
        lblDynamicText.Text = e.Param1;
        pbLoader.Step = 1;
        pbLoader.Minimum = 1;
        pbLoader.Value = 1;
        pbLoader.Maximum = e.Param2;
      }
    }
    public void OnCreate(object sender, EventArgs<String> e)
    {
      if (lblDynamicText.InvokeRequired)
      {
        lblDynamicText.Invoke(new Action<object, EventArgs<String>>(OnCreate), new Object[] { sender, e });
      }
      else
      {
        lblDynamicText.Text = e.Param1;
        pbLoader.PerformStep();
      }
    }
    public void OnFinished(object sender, EventArgs<String> e)
    {
      if (lblDynamicText.InvokeRequired)
      {
        lblDynamicText.Invoke(new Action<object, EventArgs<String>>(OnFinished), new Object[] { sender, e });
      }
      else
      {
        lblDynamicText.Text = e.Param1;
      }
    }
