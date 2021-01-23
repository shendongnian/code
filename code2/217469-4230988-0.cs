    namespace ExampleProject1.Models
    {
        public partial class ExampleProject1DataContext
        {
            public override void SubmitChanges(ConflictMode failureMode)
            {
                ManangeAndProcessChangeSet(base.GetChangeSet());
                base.SubmitChanges(failureMode);
            }
            private void ManangeAndProcessChangeSet(ChangeSet changeSet)
            {
                DateTime now = DateTime.UtcNow;
                if (changeSet.Inserts.Count > 0)
			    {
				    ProcessInserts(changeSet.Inserts, now);
			    }
			    if (changeSet.Updates.Count > 0)
			    {
				    ProcessUpdates(changeSet.Updates, now);
			    }
			    if (changeSet.Deletes.Count > 0)
			    {
				    ProcessDeletes(changeSet.Deletes, now);
			    }
            }
            private void ProcessInserts(IList<object> list, DateTime now)
            {
                IEnumerable<Cake> cakes = list.OfType<Cake>();
                IEnumerable<Topping> toppings = list.OfType<Topping>();
                // Update the created and modified times.
                foreach (Cake cake in cakes)
                {
                    cake.Guid = Guid.NewGuid();
                    cake.CreatedDateTime = now;
                    cake.ModifiedDateTime = now;
                }
                foreach (Topping topping in toppings)
                {
                    topping.Guid = Guid.NewGuid();
                    topping.CreatedDateTime = now;
                    topping.ModifiedDateTime = now;
                }
            }
            private void ProcessUpdates(IList<object> list, DateTime now)
            {
                IEnumerable<Cake> cakes = list.OfType<Cake>();
                IEnumerable<Topping> toppings = list.OfType<Topping>();
                // Update the created and modified times.
                foreach (Cake cake in cakes)
                {
                    ProcessUpdates(cake, now);
                }
                foreach (Topping topping in toppings)
                {
                    topping.ModifiedDateTime = now;
                }
            }
            private void ProcessDeletes(IList<object> list, DateTime now)
            {
                IEnumerable<Cake> cakes = list.OfType<Cake>();
                IEnumerable<Topping> toppings = list.OfType<Topping>();
                // Could create tasks here to delete associated stored files for cakes and toppings.
            }
            private bool ProcessUpdates(Cake cake, DateTime now)
            {
                bool modified = false;
                ModifiedMemberInfo[] mmi = context.Cakes.GetModifiedMembers(cake);
                foreach (ModifiedMemberInfo mi in mmi)
                {
                    switch (mi.Member.Name)
                    {
                        case "CountOfItemsSold":
                            // Exclude from updating the modified date.
                            break;
                        case "IsExpired":
                            if ((bool)mi.CurrentValue)
                            {
                                cake.ExpiredDateTime = now;
                            }
                            else
                            {
                                cake.ExpiredDateTime = null;
                            }
                            modified = true;
                            break;
                        default:
                            modified = true;
                            break;
                    }
                }
                if (modified)
                {
                    cake.ModifiedDateTime = now;
                }
                return modified;
            }
        }
    }
