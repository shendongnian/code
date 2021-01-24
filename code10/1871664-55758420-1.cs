    class Plant : Kingdom
    {
    
        public Plant()
        {
            milk = false;
            wings = false;
            fruits = true;
        }
    
        public override string me()
        {
            return "Plants";
        }
    }
    
    class Animelia : Kingdom
    {
        public Animelia()
        {
            milk = true;
            wings = true;
            fruits = false;
        }
    
        public override string me()
        {
            return "Animals";
        }
    }
    
    class Mamalia : Animelia
    {
        public Mamalia()
        {
            milk = true;
            wings = false;
            fruits = false;
        }
    
        public override string me()
        {
            return "Mamals";
        }
    }
