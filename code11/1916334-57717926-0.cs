class GenericGeometry3D<T> : Geometry3D where T : Geometry{
    T InnerGeometry;
    public GenericGeometry3D(T innerGeometry){
        InnerGeometry = innerGeometry;
    }
    //implement functionality of Geometry by redirecting to the inner geometry
    //you can auto generate these methods in VS by selecting 'Implement through'
    public void MethodInGeometry(){
       InnerGeometry.MethodInGeometry();
    }
    //...
    //extra functionality provided by Geometry3D
    //...
}
You will then automatically have `GenericGeometry3D<Circle>` and `GenericGeometry3D<Line>` classes. I'm not sure if this pattern has a name. It is a bit similar to the decorator pattern.
You can then create Circle3D as follows:
class Circle3D : GenericGeometry3D<Circle>{
  public Circle3D(...) : base (new Circle(...)) { }
}
