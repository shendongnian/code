static class ReviewCount
{
  public static int ReviewCounts
  {
    get
    {
      int fbCount = 10;
      int googleCount = 10;
      
      int total = fbCount + googleCount;
      
      return total;
    }
  }
}
Then use `<%: ReviewCounts.ReviewCounts %>` to get the value from this property from any aspx page.
