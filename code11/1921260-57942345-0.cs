C#
using LibVLCSharp.Shared;
public class RadioStream
    {
        readonly LibVLC _libVLC;
        readonly MediaPlayer _mp;
        public RadioStream()
        {
            if (DesignMode.IsDesignModeEnabled) return;
            Core.Initialize();
            _libVLC = new LibVLC();
            _mp = new MediaPlayer(_libVLC);
        }
        public void Init()
        {
            _mp.Media = new Media(_libVLC, "http://url/stream", FromType.FromLocation);
           
            _mp.Media.AddOption(":no-video");
        }
        public void Play(bool play)
        {
            if (play)
                _mp.Play();
            else _mp.Pause();
        }
        public bool isPlaying()
        {
            if (_mp.IsPlaying == false)
                return false;
            else
                return true;
        }
        
    }
And its working!  
In a while loop I check the isPlaying() that allows me to set the status of the stream and display accordingly.
Its simple at the moment, and stops playing when the internet state changes. But the above is working for simple playback.
