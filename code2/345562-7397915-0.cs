    public class DiscountFilter : IPagePreFilter<ISalesPage>
    {
        public void Process(ISalesPage page)
        {
            if (page.Product.Id == 1234)
                page.AddParagraph("Product is at amazing 50% off");
        }
    }
