    public class ShapeHolder
    {
       public IShape shape{ get; set ;}
       public string shapeName { get; set; }
    }
    //Run time shape creation
    ShapeHolder shapeholder = factory.CreateShape();
    ObjectFactory.Initialize(x =>
    {
       x.For(typeof(IShape)).Use(shapeholder.shape).Named(shapeholder.shapeName);
    } );
