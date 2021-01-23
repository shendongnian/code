    class MusicPlayer
    {
        private const int duration = 1000;
        private Queue<string> queue;
        
        public MusicPlayer(IList<string> trackFileNames)
        {
           this.queue = new Queue<string>();
           // fill queue with trackFileNames here.
           this.soundPlayer = new SoundPlayer();
           this.timer = new Timer();
           timer.Tick += new EventHandler(ClockTick);
        }
    
        public void PlayAll()
        {
           this.PlayNext();
        }
    
        private void PlayNext()
        {
           var filename = this.queue.Dequeu();
           this.soundPlayer.SoundLocation = filename;
           this.player.Play();
           this.timer.Interval = duration;
           this.timer.Start();
        }
    
        private void ClockTick(object sender, EventArgs e)
        {
        	if (queue.Count == 0 ) {
    	    	player.Stop();
        		timer.Stop();
        	}
        	else 
        	{
    			this.PlayNext();
        	}
        }
    }
