    public class MoveCurrentToNextCommand : ICommand {
        private readonly ICollectionView view;
        public MoveCurrentToNextCommand(ICollectionView view) {
            this.view = view;
            this.view.CurrentChanged += (s, e) => {
                CanExecuteChanged(this, EventArgs.Empty);
            };
        }
        public event EventHandler CanExecuteChanged = delegate { };
        public bool CanExecute(object parameter) {
            return !view.IsCurrentLast();
        }
        public void Execute(object parameter) {
            view.MoveCurrentToNext();
        }
    }
    public class MoveCurrentToPreviousCommand : ICommand {
        private readonly ICollectionView view;
        public MoveCurrentToPreviousCommand(ICollectionView view) {
            this.view = view;
            this.view.CurrentChanged += (s, e) => {
                CanExecuteChanged(this, EventArgs.Empty);
            };
        }
        public event EventHandler CanExecuteChanged = delegate { };
        public bool CanExecute(object parameter) {
            return !view.IsCurrentFirst();
        }
        public void Execute(object parameter) {
            view.MoveCurrentToPrevious();
        }
    }
