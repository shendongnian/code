        TransactionScope scope = new TransactionScope();
        try
        {
            // Body of the using statement
        }
        finally
        {
            if (scope != null)
            {
                scope.Dispose();
            }
        }
    In this case of course we know that`scope` *won't* be null because we're calling a constructor, but that's the general expansion. (You could have used a method call to obtain the transaction scope, for example - in which case it could have returned null, but the generated code won't throw a `NullReferenceException`.)
