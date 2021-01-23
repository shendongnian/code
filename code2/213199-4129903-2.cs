    public class MyObject
    {
        public string Title;
        public string AnotherProperty;
        public void populateFromForm()
        {
           Title = Request.Form["Title"];
           AnotherProperty = Request.Form["AnotherField"];
        } 
        public void populateFromXML()
        {
             // set up xml connection and read a bunch of xml values
             Title = theDataRow["title"].ToString();
             AnotherProperty = theDataRow["AnotherProperty"].ToString(); 
        }
    }
