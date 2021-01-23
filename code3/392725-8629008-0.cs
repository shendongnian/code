    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Fibonacci : IEnumerable<int>{
        delegate Tuple<int,int> update(Tuple<int,int> x);
        update func = ( x ) => Tuple.Create(x.Item2, x.Item1 + x.Item2);
    
        public IEnumerator<int> GetEnumerator(){
            var x = Tuple.Create<int,int>(0,1);
            while (true){
                yield return x.Item1;
                x = func(x);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
    
    class Sample {
        static public void Main(){
            int result= (new Fibonacci()).TakeWhile(x => x < 4000000).Where(x => x % 2 == 0).Sum();
            Console.WriteLine(result);//4613732
       }
    } 
