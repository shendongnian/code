    Var userList = Service.GetUsers() //Returns List of UserDTO;
    var excelFilePath = userList.ToExcel();
    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new FileStream(excelFilePath, FileMode.Open);
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/vnd.ms-excel");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "UserList.xls" };
    
                return result;
 
