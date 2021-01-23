	public static void InvokeIfRequired(this System.Windows.Forms.Control c,
                                        Action action) {
		if (c.InvokeRequired) {
			c.Invoke((Action)(() => action()));
		}
		else {
			action();
		}
	}
