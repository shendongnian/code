        public IEnumerable<SomeEntity> GetAllSomeEntities(Nullable<global::System.Int32> accountID)
        {
            ObjectParameter accountIDParameter;
            if (accountID.HasValue)
            {
                accountIDParameter = new ObjectParameter("accountID", accountID);
            }
            else
            {
                accountIDParameter = new ObjectParameter("accountID", typeof(global::System.Int32));
            }
            
            return this.ObjectContext.ExecuteFunction<SomeEntity>("GetAllSomeEntities", accountIDParameter);
        }
