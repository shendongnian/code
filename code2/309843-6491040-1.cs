    this.ObjectInterface.CodeIsUnique(currentObject.Code, (result, error) =>
        {
            if (error != null)
            {
                // Deal with error
            }
            else if (!result)
            {
                // Code is not unique set error state.
            }
        }
