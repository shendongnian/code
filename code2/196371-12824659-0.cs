// Hypothetical struct
public struct {
  public float xx,xy,yx,yy,dx,dy;
} Transform2d;
// Hypothetical property of "System.Drawing.Drawing2d.Matrix"
public Transform2d Transform {get;}
// Actual property of "System.Drawing.Drawing2d.Matrix"
public float[] Elements { get; }
// Code using hypothetical struct
Transform2d myTransform = myMatrix.Transform;
myTransform.dx += 20;
... other code using myTransform
// Code using actual Microsoft property
float[] myArray = myMatrix.Elements;
myArray[4] += 20;
... other code using myArray
