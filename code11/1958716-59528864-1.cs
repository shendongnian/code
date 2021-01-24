    public class Test1
    {
        public void sayHello(){
            Console.WriteLine("hehe");
        }
    }
    
    public class Test2 : Test1
    {
        public void sayHello(string inputValue){
            Console.WriteLine(inputValue);
        }
    }
