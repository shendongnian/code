        /// <summary>
        /// Retrieve the underlying ObjectContext
        /// </summary>
        public ObjectContext ObjectContext
        {
          get
          {
              return ((IObjectContextAdapter)this).ObjectContext;
          }
        }
