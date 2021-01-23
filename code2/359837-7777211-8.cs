    public interface IReviewEditableFields
    {
        int BusinessID;
        string Comments;
        int Rating;
    }
    
    // This will only update the BusinessID, Comments and Rating properties
    UpdateModel<IReviewEditableFields>(review);
