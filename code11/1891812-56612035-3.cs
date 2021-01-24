    public abstract class Compte
    {
      public int Num { get; set; } // an auto-property
      public DateTime Date { get; set; }
      public float Solde { get; set; }
      public Client Prop { get; set; }
      
      protected Compte(Compte compte)
      {
        Num = compte.Num;
        Date = compte.Date;
        Solde = compte.Solde;
        Prop = compte.Prop;
      }
    }
