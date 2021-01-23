    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
    
        class Category
        {
            public IList<Module> Modules {get; private set;}
            public IEnumerable<Module> AggregatedModules
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
                        foreach (var p in m.Products)
                        {
                            yield return p;
                        }
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
            public void Test1()
            {
                Category c = new Category();
                c.AggregatedProducts.Take(4).Skip(12);
                IList<Category> cs = new List<Category>();
                cs.EnumerablePropertyUnion(cat => cat.AggregatedProducts);
                
            }
        }
    }
    public static class EnumerableExtension
    {
        public static IEnumerable<T2> EnumerablePropertyUnion<T,T2>(
            this IEnumerable<T> enumerable,
            Func<T, IEnumerable<T2>> propertyEnumerator
            )
        {
            foreach (var item in enumerable)
            {
                foreach (var subitem in propertyEnumerator(item))
                {
                    yield return subitem;
                }
            }
        }
    }
