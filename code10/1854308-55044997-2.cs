    repository.Update(
        x => x.Id == userId, // Where clause
        x => new User{ // Update expression
            Modified = DateTime.Now,
            ModifiedBy = "John",
            Amount = x.Amount + 10
        }
    );
