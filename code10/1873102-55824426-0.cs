    public static class Extensions
    {
        public static decimal CalculateAverageRating(this IAsyncEnumerable<ProductReview> productReviews)
        {
            // Calculate and return average rating
    
            return averageRatings;
        }
    }
    var products = _context.Products
                .Include(pr => pr.ProductReviews)
                .AsQueryable().ToAsyncEnumerable();
    
            if(searchParams.Rating != 0)
                products = products.Where(p => p.ProductReviews.CalculateAverageRating() == searchParams.Rating);
