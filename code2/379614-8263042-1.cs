    var users = new List<string>();
    //fill users ... 
    var items = new List<long>();
    //fill items ... 
    var userReviews = new List<UserReview>();
    //fill userReviews (not each user reviews all atems) ... 
    var listItems = new List<ListItem>();
    
    //actual code to fill listItems 
    foreach (var item in items)
    {
        users.Sort();
        var listItem = new ListItem() {Item = item, QuantityList = new List<string>()};
        foreach (var user in users)
        {
            var review = userReviews.SingleOrDefault(x => x.Item == item && x.User == user);
            listItem.QuantityList.Add(review != null ? review.Quantity.ToString() : "-");
        }
        listItems.Add(listItem);
    }
