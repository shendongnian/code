		static AndroidJavaObject _activity;
		public static AndroidJavaObject Activity
		{
			get
			{
				if (_activity == null)
				{
					var unityPlayer = new AndroidJavaClass(C.ComUnity3DPlayerUnityPlayer);
					_activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
				}
				return _activity;
			}
		}
