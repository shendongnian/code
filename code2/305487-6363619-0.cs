    session.QueryOver<ContactAssociation>(() => contactAssociationAlias)
       .Where(() =>
           contactAssociationAlias.Contact.ID == careGiverId &&
           contactAssociationAlias.Client.ID == clientKey)
       .JoinQueryOver(() => contactAssociationAlias.AclRole)
           .Where(a => a.RoleName == "Care Giver")
       .SingleOrDefault();
