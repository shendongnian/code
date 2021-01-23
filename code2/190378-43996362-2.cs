    class PrintListToConsole<T> {
    
        private Func<T, String> _renderFunc;
    
        public void SetRenderFunc(Func<T, String> r) {
            // posso settare un diverso meccanismo di render
            _renderFunc = r;
        }
    
        public void StampaFunc(List<T> list) {
            foreach (var item in list) {
                Console.Write(_renderFunc(item));
            }
        }
    }
