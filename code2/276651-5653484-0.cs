    public class MyClass 
    {
    int one = -1;
    int two = -2;
    
    public int One { get { return this.one; }
                     set { if (this.two != -1 ) this.one == value; }}
    
    public int Two { get { return this.two; }
                     set { if (this.one!= -1 ) this.two== value; }}
    }
