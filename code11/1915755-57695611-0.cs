//Change credit to List<Credit>
public List<Credit> deductibleCredit
        {
            get
            {
                if (deductibleCredit == null)
                {
                    deductibleCredit = (from c in Credits
                                             where c.State.IsADeductible
                                             orderby c.EffectiveDate
                                             //Change .FirstOrDefault to .ToList()
                                             select c).ToList();
                    if (deductibleCredit != null)
                    {
                        if (!IsReportable(RecordTypeAlias.Deductible))
                        { 
                            deductibleCredit = null;
                        }
                    }
                }
                return deductibleCredit;
            }
        }
