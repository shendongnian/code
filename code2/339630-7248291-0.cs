    public void GetData( string filter, Action<LoadOperation<MyEntityType>> callback )
		{
			var q = from e in _context.GetDataQuery()
			        where e.SomeField.Contains(filter)
			        select e;
			_context.Load(q, LoadBehavior.RefreshCurrent, callback, null);
		}
