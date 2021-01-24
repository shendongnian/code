        DoOtherStuff() // Returns IEnumerable<Parent>
        .Select(parent => {
            parent.Children = parent.Children.OrderBy(YetAnotherPredicate).ToList();
            return parent;
        })
        .OrderByDescending(SomePredicate) 
        .ThenBy(AnotherPredicate)
        .ToList();
