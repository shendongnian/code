    public class Recorder
    {
        private IList<Action> _recording;
        public Recorder()
        {
            _recording = new List<Action>();
        }
        public void CallAndRecord(Action action)
        {
            _recording.Add(action);
            action();
        }
        public void Playback()
        {
            foreach(var action in _recording)
            {
                action();
            }
        }
    }
    //usage
    var recorder = new Recorder();
    //calls the functions the first time, and records the order, function, and args
    recorder.CallAndRecord(()=>Foo(1,2,4));
    recorder.CallAndRecord(()=>Bar(6));
    recorder.CallAndRecord(()=>Foo2("hello"));
    recorder.CallAndRecord(()=>Bar2(0,11,true));
    //plays everything back
    recorder.Playback();
