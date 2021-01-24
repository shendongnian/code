    public class Process
        {
            private Action<Result> CaptureFinished = null;
            private Sniffer _sniffer;
    
            public Process(Sniffer sniffer)
            {
                _sniffer = sniffer;
            }
    
            public Result StartProcess(Action<Result> onCaptureFinished)
            {
                CaptureFinished = onCaptureFinished;
    			...
                CaptureFinished.Invoke(result);
                _sniffer.ProcessResult(result);
    
                return new Result("OK");
            }
        }
    }
