public IHttpActionResult Get(long id, bool DataBasic)
{ 
    if (!DataBasic)
    {
        //This method returns a full Data
    }
    else
    {
       //Method Retrieving new data
    }
}
different controller
@using (Html.BeginForm(model.Databasic ? "GetNew" : "GetFull", "ControllerName", new {id = model.Id}))
{
        <input type="submit" name="Get" />
}
public IHttpActionResult GetNew(long? id)
{ 
    
    //Method Retrieving new data
}
public IHttpActionResult GetFull(long id)
{ 
    //This method returns a full Data
}
