    public class PostingApiController : ApiController
    {
        public string CreateTruckCategory(TruckAndCategory model)
        {
            try
            {
                using (var db = new YourEntity())
                {
                    //extract the truck model           
                    Truck truck = new Truck
                    {
                        //assign variables example
                        Title = model.Truck.Title;
                    };
                    //save truck data to db
                    db.Truck.Add(truck);
                    db.SaveChanges();
                    //keep track of the truck id if it is auto increment
                    var truckId = truck.TruckId;
                    //also in the same way extract and save the category model keeping track of the ID,
                    var categoryId = category.Id;
                    //the save the link table with both IDs
                    TruckCategory truckCategory = new TruckCategory
                    {
                        CategoryId = categoryId;
                        TruckId = truckId;
                    };
                    //then save this link table
                    db.TruckCategory.Add(truckCategory);
                    db.SaveChanges();
                }
                return "success";
            }
            catch (Exception e)
            {
                return "failure";
            }
        }
    }
