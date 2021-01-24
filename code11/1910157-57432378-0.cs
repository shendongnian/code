	public ActionResult<IDataObject> GetRelatedObject([CanBeNull] string className, [CanBeNull] string primaryKey, [CanBeNull] string relationName)
	{
		var validationError = ValidateRequest(className, primaryKey, relationName, allowMultipleCardinality: false);
		if (validationError) return validationError;
		
		try
		{
			var relationValue = metaObject.GetObject<IDataObject>(relation);
			return new ActionResult<IDataObject>(relationValue);
		}
		catch (InvalidAuthorizationException)
		{
			return Unauthorized();
		}
	}
	
	public ActionResult<IEnumerable<IDataObject>> GetRelatedObjects([CanBeNull] string className, [CanBeNull] string primaryKey, [CanBeNull] string relationName)
	{
		var validationError = ValidateRequest(className, primaryKey, relationName, allowMultipleCardinality: true);
		if (validationError) return validationError;
	
		try
		{
			var list = _dataAccess.GetRelatedList<IDataObject>(DataSession, metaClass, primaryKeyValues, relation);
	
			return new ActionResult<IEnumerable<IDataObject>>(list);
		}
		catch (InvalidAuthorizationException)
		{
			return Unauthorized();
		}
	}
	
	private ActionResult ValidateRequest([CanBeNull] string className, [CanBeNull] string primaryKey, [CanBeNull] string relationName, bool allowMultipleCardinality)
	{
		if (string.IsNullOrWhiteSpace(primaryKey))
		{
			return BadRequest("Primary key cannot be empty.");
		}
	
		if (!TryGetClass(className, out var metaClass))
		{
			return NotFound($"Class [{className}] does not exist.");
		}
	
		if (!metaClass.Properties.TryGetValue(relationName, out var property))
		{
			return NotFound($"Class [{metaClass}] does not contain property [{relationName}].");
		}
	
		if (!(property is IMetaRelation relation))
		{
			return BadRequest($"Property [{relationName}] is not a relation.");
		}
	
		if (AllowMultipleCardinality)
		{
			if (relation.Target.Cardinality != MetaCardinality.Multiple)
			{
				return BadRequest("The cardinality is not multiple");
			}
		}
		else
		{
			if (relation.Target.Cardinality == MetaCardinality.Multiple)
			{
				return BadRequest($"Relation [{relationName}] has multiple cardinality.");
			}
		}
	
		if (!_primaryKeyHandler.TryParsePrimaryKey(metaClass, primaryKey, out var primaryKeyValues))
		{
			return BadRequest("Cannot convert the primaryKey to the correct type.");
		}
	
		if (!_dataCalculator.SupportsData(metaClass))
		{
			return BadRequest($"The class [{className}] is not persisted");
		}
	
		var metaObject = _dataAccess.GetObject<IDataObject>(DataSession, metaClass, primaryKeyValues);
		if (metaObject == null)
		{
			return NotFound($"The metaObject for the primaryKey [{primaryKey}] nad the class [{className}] cannot be empty.");
		}
	}
