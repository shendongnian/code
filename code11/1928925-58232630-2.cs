    if (String.IsNullOrEmpty(code))
    {
        return entityContext.Set<PfBalanceValidation>().Where(e => e.Productcode == name);
    }
    else if (String.IsNullOrEmpty(name))
    {
        return entityContext.Set<PfBalanceValidation>().Where(e => e.Glcode == code);
    }
    else
    {
        return entityContext.Set<PfBalanceValidation>().Where(e => e.Productcode == name);
    }
