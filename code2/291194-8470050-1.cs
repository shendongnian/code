	public static void Main (string[] args)
	{
		Console.WriteLine ("Fmod Play File Test");
		
		Xpod.FmodSharp.Debug.Level = Xpod.FmodSharp.DebugLevel.Error;
		var SoundSystem = new Xpod.FmodSharp.SoundSystem.SoundSystem();
		
		Console.WriteLine ("Default Output: {0}", SoundSystem.Output);
		
		SoundSystem.Init();
		SoundSystem.ReverbProperties = Xpod.FmodSharp.Reverb.Presets.Room;
		
		if (args.Length > 0) {
			foreach (string StringItem in args) {
				Xpod.FmodSharp.Sound.Sound SoundFile;
				SoundFile = SoundSystem.CreateSound (StringItem);
				
				Xpod.FmodSharp.Channel.Channel Chan;
				Chan = SoundSystem.PlaySound(SoundFile);
				
				while(Chan.IsPlaying) {
					System.Threading.Thread.Sleep(10);
				}
				
				SoundFile.Dispose();
				Chan.Dispose();
			}
			
		} else {
			Console.WriteLine ("No File to play.");
		}
		
		SoundSystem.CloseSystem();
		SoundSystem.Dispose();
	}
