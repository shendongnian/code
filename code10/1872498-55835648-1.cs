    /// <summary>
    /// Inserts a Heartbeat record into local DB.
    /// </summary>
    /// <param name="heartbeat"></param>
    /// <returns></returns>
    public long InsertHeartbeat(Heartbeat heartbeat)
    {
        if (heartbeat == null) return -2L;
        // This is no longer initialized in a using() statement
        var db = this.WritableDatabase;
        
            var id = -3L;
            db.BeginTransactionNonExclusive();
            try
            {
                var cv = GetContentValues(heartbeat);
                id = db.Insert(DatabaseSchema.Heartbeat.TableName, null, cv);
                db.SetTransactionSuccessful();
            }
            catch (Exception e)
            {
                // TODO: Document Exception
                Util.Tools.Bark(e);
            }
            finally
            {
                db.EndTransaction();
            }
            return id;
        
    }
