    class ClassChildComparer : IEqualityComparer<ClassChild>
    {
        public bool Equals(ClassChild x, ClassChild y)
        {
            return x.Property == y.Property;
        }
    
        // If Equals() returns true for a pair of objects then GetHashCode() must return the same value for these objects.
        public int GetHashCode(ClassChild c)
        {
            return c.Property.GetHashCode();
        }
    
    }
    
    //and then:
    
    bool equal = obj1.ClassChildren.SequenceEqual(obj2.ClassChildren, new ClassChildComparer())
