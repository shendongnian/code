        public static class AccountStatusExtensionMethods
        {
            /// <summary>
            /// Returns the Type as enumeration for the db entity
            /// </summary>
            /// <param name="entity">Entity for which to check the type</param>
            /// <returns>enum that represents the type</returns>
            public static EAccountStatus GetAccountStatus(this Account entity)
            {
                if (entity.AccountStatus.Equals(EAccountStatus.Offline))
                {
                    return EAccountStatus.Offline;
                }
                else if (entity.AccountStatus.Equals(EAccountStatus.Online))
                {
                    return EAccountStatus.Online;
                }
                else if (entity.AccountStatus.Equals(EAccountStatus.Pending))
                {
                    return EAccountStatus.Pending;
                }
                throw new System.Data.Entity.Validation.DbEntityValidationException(
                    "Unrecognized AccountStatus was set, this is FATAL!");
            }
