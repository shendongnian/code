     public bool Delete( Entity entity )
     {
          return this.ServiceRequest( e => {
              this.repository.Remove( e );
              this.repository.Save();
          }, entity );
     }
     protected bool ServiceRequest( Action<Entity> action, Entity entity )
     {
          try
          {
              this.Validate( entity );
              action( entity );
              return true;
          }
          catch (SqlException) // only catch specific exceptions
          {
              return false;
          }
     }
