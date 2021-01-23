    public class SiteDataContextInitializer: DropCreateDatabaseIfModelChanges<SiteDataContext>
    	{
    		protected override void Seed(SiteDataContext context)
    		{
    			var brands = new List<Brand>()
    			{
    				new Brand { BrandName = "Brand 1", Slug = "brand-1" },
    				new Brand { BrandName = "Brand 2", Slug = "brand-2" }
    			};
    
    			brands.ForEach(d => context.Brands.Add(d));
    
    			base.Seed(context);
    		}
    	}
