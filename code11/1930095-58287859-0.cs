    private readonly int ObjectId = int.MinValue;
 
    protected void Page_Load(object sender, EventArgs e)
    {
       //Request["id"] is the way to read the request parameter.
       //Below we just parse it to a int and if we succeed we read the data from sql.
       if(int.TryParse(Request["id"], out ObjectId))
       {
          ReadFromSql();
       }
    }
    protected void ReadFromSql(){
       // A check if the int is filled correctly incase you call from a other method.
       if(ObjectId != int.MinValue){
          // do your sql 
       } 
    }
