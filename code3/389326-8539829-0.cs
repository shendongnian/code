        private void ContainersChanged(object sender,
            CollectionChangeEventArgs e)
        {
            // Check for a related reference being removed. 
            if (e.Action == CollectionChangeAction.Remove)
            {
                Context.DeleteObject(e.Element);
            }
        }
