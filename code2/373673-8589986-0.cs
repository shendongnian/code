    public class DataContextHelper
    {
        public static void InjectDataContext(object element, object dataContext)
        {
            if (dataContext == null)
                return;
            if (element is FrameworkContentElement)
                ((FrameworkContentElement)element).DataContext = dataContext;
            else if (element is FrameworkElement)
                ((FrameworkElement)element).DataContext = dataContext;
            TriggerUpdateOfInMemoryView();
        }
        /// <summary>
        /// Triggers an update to a view that exists only in memory, not on the screen.
        /// </summary>
        /// <remarks>
        /// When setting data context or modifying the control tree of a view that exists in
        /// memory, then those changes are not automatically visible when e.g. attempting to
        /// print the view. This function will trigger the update of the view so, e.g. a print
        /// will display the updated view.
        /// </remarks>
        public static void TriggerUpdateOfInMemoryView()
        {
            var dispatcher = Dispatcher.CurrentDispatcher;
            dispatcher.Invoke(
                DispatcherPriority.SystemIdle,
                new DispatcherOperationCallback(arg => null),
                null);
        }
    }
