    List<userReview> userReviews = GetItems();
    var groups = userReviews.GroupBy(u => u.item);
    var listItems = groups.Select(group => 
        new listItem()
        { 
            item = group.Key,
            quantityList = group.Select(g => g.User).ToList()
         }).ToList();
