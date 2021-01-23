    class Shape ()
    {
    
        virtual public void Draw()
        {
        }
    
    }
    
    class Rectangle : Shape ()
    {
    
        override public void Draw()
        {
        }
    
    }
    
    class Circle : Shape ()
    {
    
        override public void Draw()
        {
        }
    
    }
    
    
    void main ()
    {
    
        List<Shape> Shapes = new List<Shape>();
        Shapes.Add(new Rectangle());
        Shapes.Add(new Circle());
    
        Shape[1].Draw(); //Draw a rectangle
        Shape[2].Draw(); // Draw a circle
    
    }
