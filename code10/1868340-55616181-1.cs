    class Program {
        private static StartProcessX _startProcessX;
        private static StartProcessY _startProcessY;
        
        public static Main {
            _startProcessX = new StartProcessX;
            _startProcessY = new StartProcessY;
            
            _startProcessX.Start();
            _startProcessY.Start();
            // do something
            while ( running ) {
            } 
            Exit();
        }
        public static void Exit () {
            _startProcessX.Cancel();
            _startProcessY.Cancel();
        } 
    }
