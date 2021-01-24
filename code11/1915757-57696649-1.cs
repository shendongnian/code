    public List<Credit> deductibleCredit
    {
        get 
           {
              deductibleCredit = (from c in Credits
                                where c.State.IsADeductible
                                orderby c.EffectiveDate
                                select c).ToList();
           }
    }
