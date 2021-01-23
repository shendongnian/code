    interface I<S, T>
    {
        I<S, T> M();
    }
    
    class C<U, V> : I<U, V>
    {
        public I<U, V> M() {return null;}
        public C<U, V> N() {return null;}
    }
    
    public class MainClass
    {
        public static void Main()
        {
            var i1 = typeof(I<,>);
            var i2 = typeof(I<int, int>);
            var i3 = i2.GetGenericTypeDefinition();
            var i4 = i1.GetMethod("M").ReturnType;
            
            var c1 = typeof(C<,>);
            var c2 = typeof(C<int, int>);
            var c3 = c2.GetGenericTypeDefinition();
            var c4 = c1.GetMethod("N").ReturnType;
    
            var i5 = c1.GetMethod("M").ReturnType;
            var i6 = c1.GetInterfaces()[0];
            
            System.Console.WriteLine(i1 == i2); // false -- I<,> is not I<int, int>
            System.Console.WriteLine(i1 == i3); // true  -- I<int,int>'s decl is I<,>
            System.Console.WriteLine(i1 == i4); // true  -- I<,> is I<S, T>
            System.Console.WriteLine(i1 == i5); // false -- I<S, T> is not I<U, V>
            System.Console.WriteLine(i1 == i6); // false -- I<S, T> is not I<U, V>
    
            System.Console.WriteLine(c1 == c2); // false -- C<,> is not C<int, int>
            System.Console.WriteLine(c1 == c3); // true  -- C<int,int>'s decl is C<,>
            System.Console.WriteLine(c1 == c4); // true  -- C<,> is C<U,V>
        }
    }
