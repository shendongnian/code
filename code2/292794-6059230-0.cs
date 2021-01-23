    var subQuery = from t in Tasks
                   where t.TaskType == "MeterReading"
                   select t.MeterReadingOrderERPRouteCreateResponseID
    var query = from m in MeterReadingOrderERPRouteCreateResponses
                where !subQuery.Contains(m.ID)
                select new
                {
                    ID = m.ID,
                    UniqueID = m.UniqueID,
                    RouteHeaderID = m.RouteHeaderID,
                    RouteObjectState = m.RouteObjectState,
                    OriginalRouteUniqueID = m.OriginalRouteUniqueID
                };
