      public DataContext()
                : base()
      {
          this.Configuration.ProxyCreationEnabled = true;
          this.Configuration.LazyLoadingEnabled = true;
          var objectContext = ((IObjectContextAdapter)this).ObjectContext;
          objectContext.SavingChanges += new EventHandler(objectContext_SavingChanges);
      }
      private void objectContext_SavingChanges(object sender, EventArgs e)
      {
          var objectContext = (ObjectContext)sender;
          var modifiedEntities =
                objectContext.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added
                | System.Data.EntityState.Modified);
          foreach (var entry in modifiedEntities)
          {
              var entity = entry.Entity as BusinessBase;
              if (entity != null)
              {
                  entity.ModDateTime = DateTime.Now;
                  entity.ModUser = Thread.CurrentPrincipal.Identity.Name;
              }
          }
      }
