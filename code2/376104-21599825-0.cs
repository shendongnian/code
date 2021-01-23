    public class ObservableCollectionViewModel<TItemViewModel, TModel> :
        ObservableCollection<TItemViewModel>, IDisposable
        where TItemViewModel : BaseViewModel<TModel>
        where TModel : new()
    {
        private readonly ObservableCollection<TModel> models;
        private readonly Func<TModel, TItemViewModel> viewModelConstructor;
        public ObservableCollectionViewModel(ObservableCollection<TModel> models,
            Func<TModel, TItemViewModel> viewModelConstructor)
        {
            this.models = models;
            this.viewModelConstructor = viewModelConstructor;
            CreateViewModelCollection();
            models.CollectionChanged += models_CollectionChanged;
            CollectionChanged += viewModels_CollectionChanged;
        }
        private void viewModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            models.CollectionChanged -= models_CollectionChanged;
            try
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        {
                            foreach (var newItem in e.NewItems)
                            {
                                models.Add(((TItemViewModel)newItem).Model);
                            }
                            break;
                        }
                    case NotifyCollectionChangedAction.Remove:
                        {
                            foreach (var oldItem in e.OldItems)
                            {
                                models.Remove(((TItemViewModel)oldItem).Model);
                            }
                            break;
                        }
                    // TODO: Add missing actions
                    default: throw new NotImplementedException();
                }
            }
            finally
            {
                models.CollectionChanged += models_CollectionChanged;
            }
        }
        private void models_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged -= viewModels_CollectionChanged;
            try
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        {
                            foreach (var newItem in e.NewItems)
                            {
                                Add(viewModelConstructor((TModel)newItem));
                            }
                            break;
                        }
                    case NotifyCollectionChangedAction.Remove:
                        {
                            var viewModels = this.Where(viewModel => e.OldItems.Contains(viewModel.Model)).ToList();
                            foreach (var viewModel in viewModels)
                            {
                                Remove(viewModel);
                            }
                            break;
                        }
                    // TODO: Add missing actions
                    default: throw new NotImplementedException();
                }
            }
            finally
            {
                CollectionChanged += viewModels_CollectionChanged;
            }
        }
        /// <summary>
        /// Only called once, by constructor
        /// </summary>
        private void CreateViewModelCollection()
        {
            foreach (var model in models)
            {
                Add(viewModelConstructor(model));
            }
        }
        public void Dispose()
        {
            models.CollectionChanged -= models_CollectionChanged;
        }
    }
