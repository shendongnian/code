    public Monad CreateNewOrder(CustomerEntity buyer, ProductEntity item, Guid transactionGuid) {
        if (buyer == null || string.IsNullOrWhiteSpace(buyer.FirstName))
            return Monad.Failure(new ValidationException("First Name Required"));
        try {
            var orderWithNewID = ... Do Heavy Lifting Here ...;
            _eventHandler.Raise("orderCreated", orderWithNewID, transactionGuid);
        }
        catch (Exception ex) {
            _eventHandler.RaiseException("orderFailure", ex, transactionGuid); // <-- should never fail BTW
            return Monad.Failure(ex);
        }
        return Monad.Success();
    }
