        public ICommand DoSomething { get; private set; }
        public TestVM()
        {
            DoSomething = new RelayCommand<Point>(SomeAction);
        }
        private void SomeAction(Point point)
        {
            
        }
