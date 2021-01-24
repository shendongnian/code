    var foodQuery = db.Foods.Where(row => idList.Contains(row.ID));
    var rateQuery = db.Rates.Where(row => !foodQuery.Any(food => food.ID == row.FID)).Take(1);
    var result = new
    {
        food = foodQuery,
        rate = rateQuery
    };
    return Request.CreateResponse(HttpStatusCode.OK,result);
