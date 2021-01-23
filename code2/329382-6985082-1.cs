    partial class YourDataContext
    {
        public override void SubmitChanges(ConflictMode failureMode) // don't worry, the parameterless version you know calls this one...
        {
            var changeSet = GetChangeSet();
            foreach (object insert in changeSet.Inserts)
            {
                // set LastUpdate property
            }
            foreach (object update in changeSet.Updates)
            {
                // set LastUpdate property
            }
            base.SubmitChanges();
        }
    }
