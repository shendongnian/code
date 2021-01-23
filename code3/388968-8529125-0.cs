			const string pipeName = "auDeo.Server";
			var ownCmd = string.Join(" ", args);
			try
			{
				using (var ipc = new IPC(pipeName))
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					var form = new ServerForm();
					ipc.MessageReceived += m =>
					{
						var remoteCmd = Encoding.UTF8.GetString(m);
						form.Invoke(remoteCmd);
					};
					if (!string.IsNullOrEmpty(ownCmd))
						form.Invoke(ownCmd);
					Application.Run(form);
				}
			}
			catch (Exception)
			{
				//MessageBox.Show(e.ToString());
				if (string.IsNullOrEmpty(ownCmd))
					return;
				var msg = Encoding.UTF8.GetBytes(ownCmd);
				IPC.SendMessage(pipeName, msg);
			}
