    public static class Seq<T>{
        public delegate Tuple<T,T> update(Tuple<T,T> x);
    
        static public IEnumerable<T> unfold(update func, Tuple<T,T> initValue){
            var value = initValue;
            while (true){
                yield return value.Item1;
                value = func(value);
            }
        }
    }
    
    class Sample {
        static public void Main(){
            var fib = Seq<int>.unfold( x => Tuple.Create<int,int>(x.Item2, x.Item1 + x.Item2), Tuple.Create<int,int>(0,1));
            int result= fib.TakeWhile(x => x < 4000000).Where(x => x % 2 == 0).Sum();
            Console.WriteLine(result);
       }
    } 
