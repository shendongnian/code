    // ...
    Mapper.Map(source, dest);
    // Again in the next line DetectChanges() is called, but now
    // dest.Company is null. So EF will detect a change of the navigation property
    // compared to the original state
    slaumaContext.Entry(dest).State = System.Data.EntityState.Modified;
    dest.Company = oldCompany;
    // Now DetectChanges() will find that dest.Company has changed again
    // compared to the last call of DetectChanges. As a consequence it will
    // set dest.CompanyId to the correct value of dest.Company
    slaumaContext.Entry(dest).State = System.Data.EntityState.Modified;
    // dest.Company and dest.CompanyId will have the old values now
    // and SaveChanges() doesn't null out the relationship
