		PageStatePersister pageStatePersister;
		protected override PageStatePersister PageStatePersister
		{
			get
			{
				// Unlike as exemplified in the MSDN docs, we cannot simply return a new PageStatePersister
				// every call to this property, as it causes problems
				return pageStatePersister ?? (pageStatePersister = new SessionPageStatePersister(this));
			}
		}
