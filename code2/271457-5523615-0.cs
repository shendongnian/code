			IEnumerable<ObjectStateEntry> changes = this.ObjectStateManager.GetObjectStateEntries(EntityState.Added);
			foreach (ObjectStateEntry stateEntryEntity in changes)
			{
				if (!stateEntryEntity.IsRelationship && stateEntryEntity.Entity != null)
				{
					if (stateEntryEntity.Entity is User)
					{
						//Do you work here
					}
				}
			}
