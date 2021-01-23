    using System;
    using System.Windows.Data;
    using System.Threading.Tasks;
    
    internal class Test
    {
        static void Main() 
        {
            var source = "test";
            var view1 = CollectionViewSource.GetDefaultView(source);
            var view2 = CollectionViewSource.GetDefaultView(source);        
            var view3 = Task.Factory.StartNew
                (() => CollectionViewSource.GetDefaultView(source))
                .Result;
            
            Console.WriteLine(ReferenceEquals(view1, view2)); // True
            Console.WriteLine(ReferenceEquals(view1, view3)); // False
        }        
    }
