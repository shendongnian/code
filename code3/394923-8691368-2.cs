       public bool HasAnyChanges()
        {
            // Exceptions are handled by the caller
            // If anything was deleted, return true
            if (this.AnyDeleted)
            {
                return true;
            }
            else
            {
                foreach (T theItem in this)
                {
                    if (theItem.HasAnyChanges())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
