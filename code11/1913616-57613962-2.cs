  		public virtual void _(Events.FieldUpdated<FALocationHistory, FALocationHistoryExtension.usrKodeArea> e)
		{
			var row = e.Row;
			var ext = row.GetExtension<FALocationHistoryExtension>();
			e.Cache.SetValue<FALocationHistoryExtension.usrDeskripsiArea>(row, ext.UsrKodeArea);
			var KodeAreaMaster =
				PXSelect<KodeAreaMaster, Where<KodeAreaMaster.roomCD, Equal<Required<KodeAreaMaster.roomCD>>>>
					.Select(Base, ext.UsrKodeArea).First().GetItem<KodeAreaMaster>();
			e.Cache.SetValueExt<FALocationHistoryExtension.usrDeskripsiArea>();
		}
