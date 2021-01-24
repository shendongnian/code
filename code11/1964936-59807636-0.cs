    public class MyClassA
    {
        public int Test;
        public List<MyClassB> StrTest; 
        public MyClassA()
        {
            StrTest = new List<MyClassB>();
            StrTest.Add(new MyClassB());
        }
    }
    public class MyClassB
    {
        public int value;
    }
    private string ToStr(Expression<Action> exp)
    {
        string expBody = ((LambdaExpression)exp).Body.ToString();
        // some regex
        return expBody;
    }
    void main()
    {
       MyClassA A = new MyClassA();
       Expression<Action> exp = () => A.StrTest[0].value.Equals(0);
       string str = ToStr(exp);
       Console.WriteLine(str);
    }
