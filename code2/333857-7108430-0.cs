    var persister = anEvent.Persister;
    for (int i = 0; i < persister.PropertyNames.Length; i++)
    {
        var propertyType = persister.PropertyTypes[i];
        if (!propertyType.IsCollectionType)
        {
            var insertEvent = anEvent as PostInsertEvent;
            if (insertEvent != null)
            {
                var logEntry = (AuditLog) baseLog.Clone();
                logEntry.PropertyName = persister.PropertyNames[i];
                logEntry.PropertyNewValue = this.GetStateValue( insertEvent.State[i] );
                logger.DebugFormat( "Feld hinzugefuegt: '{0}' => '{1}'", logEntry.PropertyName, logEntry.PropertyNewValue );
                Session.Save( logEntry );
            }
        }
    }
