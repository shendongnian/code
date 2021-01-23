    public ViewModelType GetViewModelByKey<ViewModelType, KeyType>(KeyType key) 
            where ViewModelType : ViewModelBase, new()
        {
            IDictionary dictionary;
            var type = typeof(ViewModelType);
            if (!keyedViewModelDictionaries.TryGetValue(type, out dictionary))
            {
                dictionary = new Dictionary<KeyType, ViewModelType>();
                keyedViewModelDictionaries.Add(type, dictionary);
            }
            var viewModels = (Dictionary<KeyType, ViewModelType>)dictionary;
            ViewModelType vm;
            if (!viewModels.TryGetValue(key, out vm))
            {
                vm = new ViewModelType();
                vm.Initialize(this);
                viewModels.Add(key, vm);
            }
            return vm;
        }
