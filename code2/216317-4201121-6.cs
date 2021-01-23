    public partial class MyDataContext : DataContext
    {
        public override void SubmitChanges(ConflictMode failureMode)
        {
            ChangeSet cs = base.GetChangeSet();
            foreach (object e in cs.Updates.Union(cs.Inserts))
            {
                PropertyInfo updatedBy = e.GetType()
                    .GetProperties()
                    .FirstOrDefault(p => p.Name == "UpdatedBy");
                if (updatedBy == null)
                {
                    base.SubmitChanges(failureMode);
                    return;
                }
                string updatedByValue = updatedBy.GetValue(e, null);
                string tempValue = String.Format("{0}|{1}", updatedByValue, DateTime.Ticks;
                updatedBy.SetValue(e, tempValue);
                base.SubmitChanges(failureMode);
                   
                updatedBy.SetValue(e, tempValue.Substring(0, tempValue.LastIndexOf('|')));
                base.SubmitChanges(failureMode);
            }
        }
    }
