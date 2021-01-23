       private static double GetRating()
            {
                int star5 = 12801;
                int star4 = 4982;
                int star3 = 1251;
                int star2 = 429;
                int star1 = 1265;
    
                double rating = (double)(5 * star5 + 4 * star4 + 3 * star3 + 2 * star2 + 1 * star1) / (star1 + star2 + star3 + star4 + star5);
    
                rating = Math.Round(rating, 1);
    
                return rating;
            }
    
            static void Main(string[] args)
            {
                double rating = GetRating();
                Console.WriteLine("Your product rating: " + rating);
                Console.ReadKey();
            }
