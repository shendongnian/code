    //Here TestEntities is the class which is given from "Save entity connection setting in web.config"
    TestEntities context = new TestEntities();
 
    var query = from data in context.Employee
                orderby data.name
                select data;
 
    foreach (Employee details in query)
    {
        if (details.id == 1)
        {
            //Assign the new values to name whose id is 1
            details.name = "Sanjay";
            details. Surname="Desai";
            details.address=" Desiwadi";
        }
        else if(query==null)
         {
         details.name="Sharad";
         details.surname=" Chougale ";
         details.address=" Gargoti";
    }
 
    //Save the changes back to database.
    context.SaveChanges();
}
