    public class MassChangedEventArgs : EventArgs
    {
       public float Mass { get; private set; }
    
       public MassChangedEventArgs(float mass)
       {
         this.Mass = mass;
       }
    }
