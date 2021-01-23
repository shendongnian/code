        partial void OnContextCreated() {
            this.SavingChanges += new EventHandler(AccrualTrackingEntities_SavingChanges);
        }
        void AccrualTrackingEntities_SavingChanges(object sender, EventArgs e) {
            List<Invoice> Invoices = this.ObjectStateManager
                .GetObjectStateEntries(System.Data.EntityState.Added | System.Data.EntityState.Modified)
                .Select(entry => entry.Entity)
                .OfType<Invoice>().ToList();
            foreach(Invoice I in Invoices)
                if (I.EntityState == System.Data.EntityState.Added) {
                    //set default values
                } else {
                    //??  whatever
                }
        }
