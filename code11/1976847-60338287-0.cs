var EffectedRows = (from rfvl in FieldValuesList 
				   where rfvl.Record_RecordId == RecordId 
				   select rfvl)
				   .ToList();
foreach (var item in EffectedRows)  
{
	//this is expensive its a call to the db on each loop
	var feature  = (from RGDF in ctx.FieldValues 
					where  RGDF.RecordId == item.RecordId select RGDF
					).Single()
	feature.Amount = item.Amount;
    feature.Boolean = item.Boolean;  
}
ctx.SaveChanges();
---------------------------------------------------------
var EffectedRows = (from rfvl in FieldValuesList 
				   where rfvl.Record_RecordId == RecordId 
				   select rfvl)
				   .ToList();
				   
var ids = EffectedRows.select(x.RecordId)
var features  = ctx.FieldValues.Where(x => ids.Contains(x.RecordId).ToList();
				
//below is in mem only now.
foreach (var item in EffectedRows)  
{
	feature = features.where(x=>x.RecordId == item.RecordId).Single()
	feature.Amount = item.Amount;
    feature.Boolean = item.Boolean;  
}
//you could consider batchs... this will so help... but my guess is this will be like 13 secs or less
//you can get down to about 4 secs max if you try harder with batching
ctx.SaveChanges();
