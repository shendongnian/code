    using System;
    
    public interface ISwimmer{
    }
    
    public interface IMammal{
    }
    
    class Dolphin: ISwimmer, IMammal{
            public static void Main(){
            test();
                    }
                public static void test(){
                var Cassie = new Dolphin();
                    Cassie.swim();
                Cassie.giveLiveBirth();
                    }
    }
    
    public static class Swimmer{
                public static void swim(this ISwimmer a){
                Console.WriteLine("splashy,splashy");
                    }
    }
    
    public static class Mammal{
                public static void giveLiveBirth(this IMammal a){
    
            Console.WriteLine("Not an easy Job");
                }
    
    }
