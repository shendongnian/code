    interface IDrawable 
    {
        void Draw();
       
        // Check for obj under location
        IDrawable HitTest(Point a_loc);
    }
    
    class Rectangle : IDrawable
    {
       public Point RectLocation { get; private set; }
    
       public void Draw()
       {
         // Draw Logic using Grapsics -> should be simple you can use existing in.Net Rectangle class
       };
       public IDrawable HitTest(Point a_loc)
       {
         // match's locations
       }
    }
    
    // Drawing on custom User Control (surface)
    
    foreach (var oRect in Rectangles)
    {
       oRect.Draw();
    }
    
    // Mouse -> just handle mouse move event invoke HitTest() with current point
