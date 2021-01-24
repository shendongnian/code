    public class Attribute
    {  
        private int _base;
        private int _mods;
    
        public Attribute (int b, int m)
        {
            _base = b;
            _mods = m;
        }
    
        public static implicit operator int(Attribute attr) => attr._base + attr._mods;
    
        public override string ToString() => $"{this._base + this._mods}";
    }
    
    public class UseAttribute
    {
        private Attribute att;
    
        public UseAttribute()
        {
            att = new Attribute(5,2);
        }
    
        public void CheckAttribute()
        {
            console.WriteLine("att: " + att); //Outputs:"att: 7"
        }
    }
