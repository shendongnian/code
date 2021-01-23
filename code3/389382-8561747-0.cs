    interface ISum{
       
       int Sum(int a, int b);
    }
    
    interface ISample
    {
        int Multiplication(int x, int a, int b);
    }
    
    public class Sample : ISample
    {
       ISum _sum;
        public Sample(ISum sum)
        {
          _sum = sum;
        }
    
       int Multiplication(int x, int a, int b)
       {
           return x*_sum.Sum(a,b);
       }
    }
