        public static MembershipUser GetUserFromEntity(this UserEntity userEntity)
        {
            return new MembershipUser(
                    Membership.Provider.Name, 
                    userEntity.Username,
                    userEntity.PartitionKey,
                    userEntity.Email,
                    userEntity.PasswordQuestion,
                    userEntity.Comment,
                    userEntity.IsApproved,
                    userEntity.IsLockedOut,
                    userEntity.CreationDate,
                    userEntity.LastLoginDate,
                    userEntity.LastActivityDate,
                    userEntity.LastPasswordChangedDate,
                    userEntity.LastLockedOutDate
                );
        }
