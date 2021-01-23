     public void FailOrProceed(Func<bool> validationFunction, Action proceedFunction, string errorMessage)
        {
            // !!! check for nulls, etc
            if (!validationFunction())
            {
                throw new ArgumentOutOfRangeException(errorMessage);
            }
    
            proceedFunction();
        }
