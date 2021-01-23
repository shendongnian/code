    public partial class MyDataContext : DataContext
    {
        public override void SubmitChanges(ConflictMode failureMode)
        {
            ChangeSet cs = base.GetChangeSet();
            foreach (object e in cs.Updates.Union(cs.Inserts))
            {
                if (typeof(IAuditable).IsAssignableFrom(e))
                {
                    string tempValue = String.Format("{0}|{1}", ((IAuditable)e).UpdatedBy, DateTime.Ticks);
                    ((IAuditable)e).UpdatedBy = tempValue;
                    base.SubmitChanges(failureMode);
                    ((IAuditable)e).UpdatedBy = tempValue.Substring(0, tempValue.LastIndexOf('|'));
                    base.SubmitChanges(failureMode);
                }
            }
        }
    }
