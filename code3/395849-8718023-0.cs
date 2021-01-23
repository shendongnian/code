    private float inverseMass;
    
    public float InverseMass{
       set
       {
            onMassChanged();
            inverseMass=value;
       }
       get
       {
          return inverseMass;
       }
    }
