    class PrintListToConsole<T> {
    
        private PrindListConsoleRender<T> _renderer;
    
        public void SetRenderer(PrindListConsoleRender<T> r) {
            // posso settare un diverso meccanismo di render
            _renderer = r;
        }
    
        public void PrintToConsole(List<T> list) {
            foreach (var item in list) {
                Console.Write(_renderer.Render(item));
            }
        }   
    }
