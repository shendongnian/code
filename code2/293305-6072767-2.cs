public void AddSomethingToDatabase(string param1, int param2)
{
   Dictionary&lt;string, object&gt; parameters = new Dictionary&lt;string, object&gt;();
   parameters.Add("pID", param1);
   parameters.Add("pName", param2);
   ModifyDatabase(parameters, "update_myTable");
}
public void ModifyDatabase(Dictionary&lt;string, object&gt; parameters, string procedure)
{
   // Do necessary checks on parameters here
   // Check database availability
   // And many other checks that would be recurring for every database transaction
   // ... that's why I have them all in one place. Executing Queries is the same
   // ... every time. Why would you write the error handling twice? :-)
   // Loop parameters and fill procedure parameters
   // Execute the lot
}
