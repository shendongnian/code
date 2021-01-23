    class A{
        private int _calls;
        private Stopwatch _sw;
        public A(){
           _calls = 0;
           _sw = new StopWatch();
           _sw.Start();
        }
        public void MethodToMeasure(){
            //Do stuff
            _calls++;
            if(sw.ElapsedMilliseconds > 1000){
                _sw.Stop();
                //Save or print _calls here before it's zeroed
                _calls = 0;
                _sw.Restart();
            }
        }
    }
