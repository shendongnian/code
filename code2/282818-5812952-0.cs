    #psudo 
    class Organism{
       public abstract void legs(){ return 0;}
    }
    class Dog : Organism{
       private int _legs;
       public int legs(){ return _legs; }
    }
