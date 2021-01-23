    public class yourClass
    {
        // ...
        // ...
    
        public yourClass DeepCopy()
        {
            yourClass othercopy = (yourClass)this.MemberwiseClone();
            return othercopy;
        }
    }
