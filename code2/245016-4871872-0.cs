    public class HttpShoppingCartFactory : IShoppingCartFactory
    {
        private readonly IShoppingUnitOfWorkFactory uowFactory;
        public HttpShoppingCartFactory(
            IShoppingUnitOfWorkFactory uowFactory)
        {
            this.uowFactory = uowFactory;
        }
        public ShoppingCart GetCartForCurrentUser()
        {
            int userId = (int)HttpContext.Current.Session["userId"];
            using (var unitOfWork = this.uowFactory.CreateNew())
            {
                return unitOfWork.ShoppingCards
                    .FirstOrDefault(c => c.User.Id == userId);
            }
        }
    }
