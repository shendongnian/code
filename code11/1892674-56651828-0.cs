     private void OnLoadingModuleEntity(IList<EntityBase> entities)
      {     
            ObservableCollection<TestEntityBase> tempObservable = new ObservableCollection<TestEntityBase>();
            foreach (EntityBase entity in entities)
            {
                TestEntityBase entityBase = new TestEntityBase();
                // Conversion logic goes here
                //
                tempObservable.Add(entityBase);                        
            }
            Details = tempObservable;  
      }
