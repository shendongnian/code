    public class Rectangle : Shape{
       public virtual int Width{get;set}
       public virtual int Height{get;set}
    }
    
    public class Square : Rectangle{
       public override int Width{get{return Height;} set{Height = value;}}
    }
