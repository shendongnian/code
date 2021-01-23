    publc class Entity
    {
         public UID ID { get; set; }
         public void Foo( UID otherID )
         {
             if (otherID.Value == this.ID.Value)
             {
                 ...
             }
         }
    }
    }
