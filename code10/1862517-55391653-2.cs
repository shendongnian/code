    public IActionResult DownloadExcel(IList<string> fields)
    {
        // get the required field list
        var userType = typeof(UserTable);
        fields = userType.GetProperties().Select(p => p.Name).Intersect(fields).ToList();
        if(fields.Count == 0){ return BadRequest(); }
        using (ExcelPackage package = new ExcelPackage())
        {
            IList<UserTable> userList = _context.UserTable.ToList();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("DbTableName");
            // generate header line
            for(var i= 0; i< fields.Count; i++ ){
                var fieldName = fields[i];
                var pi= userType.GetProperty(fieldName);
                var displayName =  pi.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                worksheet.Cells[1,i+1].Value = string.IsNullOrEmpty(displayName ) ? fieldName : displayName ;
            }
            // generate row lines
            int totalUserRows = userList.Count();
            for(var r=0; r< userList.Count(); r++){
                var row = userList[r];
                for(var c=0 ; c< fields.Count;c++){
                    var fieldName = fields[c];
                    var pi = userType.GetProperty(fieldName);
                    // because the first row is header 
                    worksheet.Cells[r+2, c+1].Value = pi.GetValue(row);
                }
            }
            var stream = new MemoryStream(package.GetAsByteArray());
            return new FileStreamResult(stream,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
You could configure the display name using the **`DsiplayNameAttribute`**:
    public class UserTable
    {
        public int Id{get;set;}
        [DisplayName("First Name")]
        public string fName { get; set; }
        [DisplayName("Last Name")]
        public string lName { get; set; }
        [DisplayName("Gender")]
        public string gender { get; set; }
    }
It's possible to add any properties as you like without hard-coding in your `DownloadExcel` method.
**Demo** :  
passing a field list `fields[0]=fName&fields[1]=lName&fields[2]=Non-Exist` will generate an excel as below:
[![enter image description here][1]][1]
**[Update]**
To export all the fields, we could assume the client will not pass a `fields` parameter. That means when the fields is `null` or if the `fields.Count==0`, we'll export all the fields:
    [HttpGet("download")]
    public IActionResult DownloadExcel(IList<string> fields)
    {
        // get the required field list
        var userType = typeof(UserTable);
        var pis= userType.GetProperties().Select(p => p.Name);
    
        if(fields?.Count >0){
            fields = pis.Intersect(fields).ToList();
        } else{
            fields = pis.ToList();
        }
     
        using (ExcelPackage package = new ExcelPackage()){
           ....
        }
    }
[![A][2]][2] 
  [1]: https://i.stack.imgur.com/FrU7N.png
  [2]: https://i.stack.imgur.com/wniQp.png
