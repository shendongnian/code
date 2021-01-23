    using(var context = new ItemEntities())
    {
        var itemList = context.Items.Where(x => !x.Items && x.DeliverySelection)
                                    .OrderByDescending(x => x.Delivery.SubmissionDate);
    }
