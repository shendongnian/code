    public classBaseEntityModel<T> : where T : IEntity2 // We use llblgen here
    {
         ... code
         
         public T Entity { get; set; }
         public void Save()
         {
               Entity.Save(); // Save is from IEntity2
         }
         ... code
    }
