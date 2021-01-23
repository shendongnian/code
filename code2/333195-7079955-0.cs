    public IEnumerable<Tuple<string,int>> getNumReviews(int RestID)
    {
        return
        (
            from REVIEW in db.REVIEWs
            where REVIEW.REST_ID == RestID
            group REVIEW by REVIEW.REVIEW_ID into t
            select new Tuple<string,int>( t.Key, t.Count() );
        );
    }
