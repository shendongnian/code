    // Data access belongs in its own area. Don't do it alongside HTML generation.
    // Program to an interface so you can mock this repository in unit tests.
    public interface ICategoryInfoRepository {
        IEnumerable<CategoryInfo> GetCategoryInfo();
    }
    
    public class CategoryInfo {
        public string CategoryName {get;set;}
        public IEnumerable<string> SubCategoryNames {get;set;}
    }
    
    public class CategoryInfoRepository : ICategoryInfoRepository 
    {
        public IEnumerable<CategoryInfo> GetCategoryInfo()
        {
            // The 'using' clause ensures that your context will be disposed
            // in a timely manner.
            using (var dbm = new MyDataContext())
            {
                // This query makes it pretty clear what you're selecting.
                // The groupings are implied.
                var q = from category in dbm.Categories
                        select new {
                            CategoryName = category.Name,
                            SubCategoryNames = 
                                from subcategory in category.SubCategories
                                select subcategory.Name
                        };
                // Make sure all the data is in memory before disposing the context
                return q.ToList(); 
            }
        }
    }
    // Since all this method does is convert its input into a string, it would
    // be very easy to unit-test.
    public string GetCategoriesHtml(IEnumerable<CategoryInfo> categoryInfos) {
        // A StringBuilder will make this HTML generation go much faster
        var sb = new StringBuilder();
        // Don't use tables to represent non-tabular data.
        // This is a list, so let's make it a list.
        // Use CSS to format it to your liking.
        sb.Append("<ul>");
        foreach(var categoryInfo in categoryInfos)
        {
            sb.Append("<li>").Append(categoryInfo.CategoryName).Append("<ul>");
            foreach(var subCategoryName in categoryInfo.SubCategoryNames)
            {
                sb.Append("<li>").Append(subCategoryName).Append("</li>");
            }
            sb.Append("</ul></li>");
        }
        sb.Append("</ul>");
        return sb.ToString();
    }
    public void DisplayLinqCategory()
    {
        // The repository would ideally be provided via dependency injection.
        var categoryInfos = _categoryInfoRepository.GetCategoryInfo();
        resultSpan.InnerHtml = GetCategoriesHtml(categoryInfos);
    }
