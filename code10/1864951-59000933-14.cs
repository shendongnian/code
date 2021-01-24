    public class MoveCurrentToNextCommand : ICommand {
        private readonly ICollectionView view;
        public MoveCurrentToNextCommand(ICollectionView view) {
            this.view = view;
            this.view.CurrentChanged += (s, e) => {
                CanExecuteChanged(this, EventArgs.Empty);
            };
        }
        public event EventHandler CanExecuteChanged = delegate { };
        public bool CanExecute(object parameter = null) => view.CanMoveCurrentToNext();
        public void Execute(object parameter = null) {
            if (CanExecute(parameter))
                view.MoveCurrentToNext();
        }
    }
