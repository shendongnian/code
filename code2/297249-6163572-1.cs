    class Rectangle : Shape
    {
        public override Boolean Intersects(Shape other)
        {
            if (other is Rectangle)
            {
                return IntersectionChecker.Intersect(this, (Rectangle)other);
            }
            else if (other is Circle)
            {
                return IntersectionChecker.Intersect(this, (Circle)other);
            }
            
            throw new NotSupportedException();
        }
    }
