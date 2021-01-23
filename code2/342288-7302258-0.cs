    public class Music
    {
        private SomeDelegateType callback
        //...
        public Music(string file)
        {
            File = file;
            callback = new SomeDelegateType(channelCallback);
        }
    
        public virtual void Play()
        {
            Audio.System.playSound(channel == null ? CHANNELINDEX.FREE : CHANNELINDEX.REUSE, music, false, ref channel);
            music.addSyncPoint(500, TIMEUNIT.MS, "wooo", ref syncPtr);
            channel.setCallback(callback);
        }
