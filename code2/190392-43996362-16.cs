    class PrintListToConsole<T> {
    
        private PrintListConsoleRender<T> _renderer;
    
        public void SetRenderer(PrintListConsoleRender<T> r) {
            // this is the point where I can personalize the render mechanism
            _renderer = r;
        }
    
        public void PrintToConsole(List<T> list) {
            foreach (var item in list) {
                Console.Write(_renderer.Render(item));
            }
        }   
    }
