    partial class YourDataContext
    {
        public override void SubmitChanges()
        {
            var changeSet = GetChangeSet();
            foreach (object insert in changeSet.Inserts)
            {
                // set LastUpdate property
            }
            foreach (object insert in changeSet.Updates)
            {
                // set LastUpdate property
            }
            base.SubmitChanges();
        }
    }
