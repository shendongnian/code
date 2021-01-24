    if (String.IsNullOrEmpty(code))
    {
        return entityContext.Set<PfBalanceValidation>().Where(e.Productcode == name);
    }
    else if (String.IsNullOrEmpty(name))
    {
        return entityContext.Set<PfBalanceValidation>().Where(e.Glcode == code);
    }
    else
    {
        return entityContext.Set<PfBalanceValidation>().Where(e.Productcode == name);
    }
