    public static class DispatcherHelper 
    { 
        public static void DoEvents() 
        {
            DispatcherFrame frame = new DispatcherFrame(); 
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(ExitFrame), frame);
            Dispatcher.PushFrame(frame); 
        } 
        
        private static object ExitFrame(object frame) 
        { 
            ((DispatcherFrame)frame).Continue = false; 
            return null; 
        } 
    }
