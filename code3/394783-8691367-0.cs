	void Application_Start(object sender, EventArgs e) {
		Application["OnlineUsers"] = 0;
	}
	void Session_Start(object sender, EventArgs e) {
		Application.Lock();
		Application["OnlineUsers"] = (int)Application["OnlineUsers"] + 1;
		Application.UnLock();
	}
	void Session_End(object sender, EventArgs e) {
		Application.Lock();
		Application["OnlineUsers"] = (int)Application["OnlineUsers"] - 1;
		Application.UnLock();
	}
