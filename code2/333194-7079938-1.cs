    public IEnumerable<NumReviewsInfo> getNumReviews(int RestID)
    {
        var NumReviews = from REVIEW in db.REVIEWs
                         where REVIEW.REST_ID == RestID
                         group REVIEW by REVIEW.REVIEW_ID into t
                         select new NumReviewsInfo { ReviewId = t.Key, NumTags = t.Count() };
        return NumReviews;
    }
