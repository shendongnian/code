		[ClassInitialize()]
		public static void MyClassInitialize(TestContext testContext) {
			mHost = new ServiceHost(typeof(TestService));
			mHost.Open();
			return;
		}
		[ClassCleanup()]
		public static void MyClassCleanup() {
			if(mHost != null) {
				mHost.Close();
			}
			return;
		}
