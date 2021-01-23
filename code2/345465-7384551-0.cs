    private static List<Field.Info> FromDatabase(this Int32 _campId)
    {
        List<Field.Info> lstFields = new List<Field.Info>();
        Field.List.Response response = new Field.List.Ticket
        {
            campId = _campId
        }.Commit();
        if (response.status == Field.List.Status.success)
        {
            lstFields = response.fields;
            lock (campIdLock)
            {
                loadedCampIds.Add(_campId);
            }
        }
        if (response.status == Field.List.Status.retry)
        {
            Thread th1 = new Thread(new ParameterizedThreadStart(FromDatabase));
            th1.Start(_campId);
        }
        return lstFields;
    }
