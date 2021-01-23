    private void RemoveSpecificInstance(IList<int> ids, ObservableCollection<SomeClass> currentCollection)
        {
            if (ids.Count == 0) 
            {
                // The initial collection didn't have children
                return;
            }
            else if (ids.Count == 1)
            {
                currentCollection.RemoveAt(ids.Single());
            }
            else
            {
                int index = ids.First();
                RemoveSpecificInstance(ids.Skip(1).ToList(), currentCollection[index].ChildElements);
            }
        }
