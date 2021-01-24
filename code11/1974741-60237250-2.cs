    interface IShapes
    {
       void DrawShape();
       
     }
    
    class Circle : IShapes
    {
        
        public void DrawShape()
        {
            Console.WriteLine("Implementation to Draw a Circle");
        }
    }
    
    Class Triangle: IShapes
    {
         public void DrawShape()
        {
            Console.WriteLine("Implementation to draw a Triangle");
        }
    }
