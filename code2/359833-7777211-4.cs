    MembershipUser user = Membership.GetUser(User.Identity.Name);
    Guid guid = (Guid)user.ProviderUserKey;
    // Copy form values
    UpdateModel(review, new string[] { "BusinessID", "Comments", "Rating" });
    
    // Overwrite custom values
    review.UserID = guid;
    reviewsRepository.AddNewReview(review);
    reviewsRepository.Save();
