    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
    
        class Category
        {
            public IList<Module> Modules {get; private set;}
            public IEnumerable<Product> AggregatedModules
            {
                get
                {
                    foreach (var p in Modules)
                    {
                        yield return p;
                    }
                }
            }
            public IEnumerable<Product> AggregatedProducts
            {
                get
                {
                    foreach (var m in Modules)
                    {
                        yield return m.AggregatedProducts;
                    }
                }
            }
        }
        class Module
        {
            public IList<Product> Products {get; private set;}
            public IEnumerable<Product> AggregatedProducts
            {
                get
                {
                    foreach (var p in Products)
                    {
                        yield return p;
                    }
                }
            }
        }
        class Product
        {
        }
        class Test
        {
            public void Test()
            {
                Category c = new Category();
                c.AggregatedProducts.Take(4).Skip(12);
            
            }
        }
    }
