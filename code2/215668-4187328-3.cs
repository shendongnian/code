    public class LabelX
    {
       private float mass;
       public float Mass
       {
           get
           {
             return mass;
           }
           set
           {
             mass = value;
             OnMassChanged();
           }
       }
       
       public event MassChangedEventHandler MassChanged;
       private void OnMassChanged()
       {
           if(MassChanged!=null)
              this.MassChanged(this, new MassChangedEventArgs(this.Mass));
       }
       
       //the rest of your code here...
    }
