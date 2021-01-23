    internal class MusicPlayer
	{
		private const int duration = 1000;
		private Queue<string> queue;
		private SoundPlayer soundPlayer;
		private Timer timer;
		
		public MusicPlayer(params object[] filenames)
		{
			this.queue = new Queue<string>();
			foreach (var filenameObject in filenames)
			{
				var filename = filenameObject.ToString();
				if (File.Exists(filename))
				{
				    this.queue.Enqueue(filename);
				}
			}
			
			this.soundPlayer = new SoundPlayer();
			this.timer = new Timer();
			timer.Elapsed += new System.Timers.ElapsedEventHandler(ClockTick);
		}
		public event EventHandler OnDonePlaying;
		
		public void PlayAll()
		{
			this.PlayNext();
		}
		private void PlayNext()
		{
			this.timer.Stop();
			var filename = this.queue.Dequeue();
			this.soundPlayer.SoundLocation = filename;
			this.soundPlayer.Play();
			this.timer.Interval = duration;
			this.timer.Start();
		}
		private void ClockTick(object sender, EventArgs e)
		{
			if (queue.Count == 0 ) {
				this.soundPlayer.Stop();
				this.timer.Stop();
				if (this.OnDonePlaying != null)
				{
					this.OnDonePlaying.Invoke(this, new EventArgs());
				}
			}
			else 
			{
				this.PlayNext();
			}
		}
	}
