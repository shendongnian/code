	//TinyIoC.TinyIoCContainer.Current.Register<RazorViewEngine>(); // WORKS
	//RazorViewEngine rve = new RazorViewEngine(); // WORKS
	m_Host = new NancyHost(m_Uri);
	//TinyIoC.TinyIoCContainer.Current.Register<RazorViewEngine>(); // WORKS
	m_Host.Start();
	TinyIoC.TinyIoCContainer.Current.Register<RazorViewEngine>(); // WORKS
