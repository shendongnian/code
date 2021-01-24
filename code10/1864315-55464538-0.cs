[HttpPost]
public async Task<ActionResult<WorkOrder>> CreateWorkOrderFromPending([FromBody]WorkOrder call)
{
    // Insert the Work Order to the DB:
    // WorkOrdersContext.WorkOrders.Add(call);
    var entity = WorkOrdersContext.WorkOrders.Attach(call);
    entity.State = EntityState.Added;
    var saveResult = await CmsDbContext.SaveChangesAsync();
    // Check if any oddities occurred during the save:
    if (saveResult == 0) return BadRequest("An Error occurred during saving and the Call was not saved, please try again.");
    // Return the Inserted Work Order:
    return Ok(call);
}
Using .Attach() instead of .Add() did the trick, placing the entity in and mapping up the FKs to their respective Shadow Properties from my Fluent mappings!
