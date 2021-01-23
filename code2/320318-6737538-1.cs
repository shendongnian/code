    public void PlayBack()
    {
       var recordedClick = _clickQueue.Dequeue();
       while (recordedClick != null)
       {
           Thread.Sleep(recordedClick.DelayTime);
           DoAction(recordedClick.Button);
           recordedClick = _clickQueue.Dequeue();
       }
    }
