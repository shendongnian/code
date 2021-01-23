    List<Entities.Base> bases = this.GetAllBases(); 
    List<Entities.Base> thebases = new List<Entities.Base>(
                                from aBase in bases  
                                where aBase.OfficeCD == officeCD  
                                select new Entities.Base {
                                    BaseCD = aBase.BaseCD,
                                    BaseName = aBase.BaseName,
                                    OfficeCD = aBase.OfficeCD,  
                                    EffectiveDate = aBase.EffectiveDate,  
                                    ExpirationDate = aBase.ExpirationDate
                            };  
