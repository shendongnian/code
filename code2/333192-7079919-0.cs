    struct Data { 
      internal int REVIEW_ID;
      internal int TagCount;
    }
    public IEnumerable<Data> getNumReviews(int RestID) {
        var NumReviews = from REVIEW in db.REVIEWs
                         where REVIEW.REST_ID == RestID
                         group REVIEW by REVIEW.REVIEW_ID into t
                         select new Data { REVIEW_ID = t.Key, TagCount = t.Count() };
        return NumReviews;
    }
