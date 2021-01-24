C#
    
    public interface IA
    {
        public int Data { get; set; }
    } 
    public class A1 : IA
    {
        public int Data { get; set; }
        public A1(int data) => Data = data * 12;
    }
    public class A2 : IA
    {
        public int Data { get; set; }
        public A1(int data) => Data = data / 144;
    }
    public int GetData(IA a) => return a.Data;
    GetData(new A1(1));     // -> 12
    GetData(new A2(144));   // -> 1
