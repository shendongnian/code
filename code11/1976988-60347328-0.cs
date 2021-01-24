//Create and add term
var transaction = await db.Database.BeginTransactionAsync();
var termEntity = new Term
{
     TermId = termId.Value
};
if (db.Terms.Find(termId.Value) == null)
{
    db.Terms.Add(termEntity);
}
else
{
    db.Terms.Update(termEntity);
}
db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Terms ON;");
await db.SaveChangesAsync();
db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Terms OFF");
//Create and add termLocalization
TermLocalization termLocalizationEntity = new TermLocalization
{
    TermId = termId.Value,
    LocalizationId = language,
    Roots = rootsEntities,
    Examples = listExamplesEntities,
    Word = term,
    Definition = definition,
    Note = notes,
    FirstOccurence = occurence,
    LastUpdateDate = DateTime.Today
};
if (db.TermLocalizations.SingleOrDefaultAsync(x => x.TermId == termId && x.LocalizationId == language).Result == null)
{
    db.TermLocalizations.Add(termLocalizationEntity);
}
else
{
    db.TermLocalizations.Update(termLocalizationEntity);
}
await db.SaveChangesAsync();
await transaction.CommitAsync();
ligne++;
