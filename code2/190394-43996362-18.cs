    class PrintListToConsole<T> {
    
        private Func<T, String> _renderFunc;
    
        public void SetRenderFunc(Func<T, String> r) {
            // this is the point where I can set the render mechanism
            _renderFunc = r;
        }
    
        public void Print(List<T> list) {
            foreach (var item in list) {
                Console.Write(_renderFunc(item));
            }
        }
    }
