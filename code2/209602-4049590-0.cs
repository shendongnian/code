            var dataRaw = new DataRaw();
            Entity testEntity = dataRaw;
            var entityObservable = new ObservableCollection<Entity>();
            entityObservable.Add(dataRaw); // This is OK
            var dataRawObservable = new ObservableCollection<DataRaw>();
            dataRawObservable.Add(dataRaw); // This is fine too.
            entityObservable = dataRawObservable; // This is not valid
            var metaDictionary = new Dictionary<Int32, ObservableCollection<Entity>>();
            metaDictionary.Add(1, dataRawObservable); // This isn't valid either.
            metaDictionary.Add(2, entityObservable); // This is valid.
