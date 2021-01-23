    if (AgeItem.AgeIndex != null)
    {
       SqlParameter[] parameters = new SqlParameter[1];
       SqlParameter planIndexParameter = new SqlParameter("@AgeIndex", SqlDbType.Int);
       planIndexParameter.Value = AgeItem.AgeIndex;
       parameters[0] = planIndexParameter;
    }
