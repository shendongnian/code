    public class Recorder
    {
        private IList<Action> _recordedFunctions;
        public Recorder()
        {
            _recordedFunctions = new List<Action>();
        }
        public void CallAndRecordFunction(Action action)
        {
            _recordedFunctions.Add(action);
            action();
        }
        public void Playback()
        {
            foreach(var action in _recordedFunctions)
            {
                action();
            }
        }
    }
    //usage
    var recorder = new Recorder();
    //calls the functions the first time, and records the order, function, and args
    recorder.CallAndRecordFunction(()=>Foo(1,2,4));
    recorder.CallAndRecordFunction(()=>Bar(6));
    recorder.CallAndRecordFunction(()=>Foo2());
    recorder.CallAndRecordFunction(()=>Bar2(0,11));
    //plays everything back
    recorder.Playback();
