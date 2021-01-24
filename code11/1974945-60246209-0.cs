    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        PersonOrganisationRoleModel p = obj as PersonOrganisationRoleModel;
        return this.OrganisationID == p.OrganisationID && this.PersonID == p.PersonID;
    }
