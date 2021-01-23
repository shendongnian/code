	using SKYPE4COMLib;
	namespace SO5673842
	{
		class Program
		{
			static void Main()
			{
				var skype = new Skype();
				skype.CurrentUserProfile.MoodText = "Hello!";
			}
		}
	}
