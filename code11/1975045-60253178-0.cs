cs
try
{
    //_unitOfWorkAsync.SaveChangesAsync();
}
catch (DbEntityValidationException ex)
{
    var sb = new StringBuilder();
    foreach (var failure in ex.EntityValidationErrors)
    {
        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
        foreach (var error in failure.ValidationErrors)
        {
            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
            sb.AppendLine();
        }
    }
    Debug.WriteLine(sb.ToString());
}
catch (Exception ex)
{
    Debug.WriteLine(ex.Message);
}
