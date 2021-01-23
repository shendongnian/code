    class PrintListToConsole<T> {
    
        private PrindListConsoleRender<T> _renderer;
    
        public void SetRenderer(PrindListConsoleRender<T> r) {
            // this is the poin where I can personalize the render mechanism
            _renderer = r;
        }
    
        public void PrintToConsole(List<T> list) {
            foreach (var item in list) {
                Console.Write(_renderer.Render(item));
            }
        }   
    }
