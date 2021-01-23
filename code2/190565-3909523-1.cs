    public class DispatchingObservableCollection<T> : ObservableCollection<T>
    {
        /// <summary>
        /// The default constructor of the ObservableCollection
        /// </summary>
        public DispatchingObservableCollection()
        {
            //Assign the current Dispatcher (owner of the collection)
            _currentDispatcher = Dispatcher.CurrentDispatcher;
        }
        private readonly Dispatcher _currentDispatcher;
        /// <summary>
        /// Executes this action in the right thread
        /// </summary>
        ///<param name="action">The action which should be executed</param>
        private void DoDispatchedAction(Action action)
        {
            if (_currentDispatcher.CheckAccess())
                action();
            else
                _currentDispatcher.Invoke(DispatcherPriority.DataBind, action);
        }
        /// <summary>
        /// Clears all items
        /// </summary>
        protected override void ClearItems()
        {
            DoDispatchedAction(() => base.ClearItems());
        }
        /// <summary>
        /// Inserts a item at the specified index
        /// </summary>
        ///<param name="index">The index where the item should be inserted</param>
        ///<param name="item">The item which should be inserted</param>
        protected override void InsertItem(int index, T item)
        {
            DoDispatchedAction(() => base.InsertItem(index, item));
        }
