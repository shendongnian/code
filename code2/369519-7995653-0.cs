    public interface ICareWhenAModelChanges<T>
    {
        void ModelUpdated(T updatedModel);
    }
    public class ModelChangeMediator<T>
    {
        private List<ICareWhenAModelChanges<T>> _listeners = new List<ICareWhenAModelChanges<T>>();
        public void Register(ICareWhenAModelChanges<T> listener)
        {
            _listeners.Add(listener);
        }
        public void NotifyThatModelIsUpdated(T updatedModel)
        {
            foreach (var listener in _listeners) listener.ModelUpdated(updatedModel);
        }
    }
