    public class RecordedEvent
    {
        public Button Button { get; set; } 
        public TimeSpan DelayTime { get; set; }
    }
    private Queue<RecordedEvent> _clickQueue = new Queue<RecordedEvent>();
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var clickTime = DateTime.Now;
        //record the click by adding it to the queue
        _clickQueue.Enqueue(new RecordedEvent()
             { 
                 Button = button,
                 DelayTime = _lastClickTime - clickTime;
              };
        _lastClickTime = clickTime;
        DoAction(button); //do what ever needs to be done when the button it clicked
    }
