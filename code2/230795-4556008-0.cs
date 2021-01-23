    SqlParameter[] parameters = new SqlParameter[1];    
    SqlParameter planIndexParameter = new SqlParameter("@AgeIndex", SqlDbType.Int);
    planIndexParameter.IsNullable = true; // Add this line
    planIndexParameter.Value = (AgeItem.AgeIndex== null) ? DBNull.Value : AgeItem.AgeIndex== ;
    parameters[0] = planIndexParameter;
