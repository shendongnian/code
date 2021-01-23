    using MyProject.SomeLinqToSqlNamespace;
    
    namespace MyProject.Areas.Admin.Models.Category
    {
        public class Edit
        {
            public IQueryable<Category> // this throws an intellisense error since it
                                        // understands "Category" as the folder/namespace
                                        // instead of the table name in linq to sql class
            // ...other code
        }
    }
