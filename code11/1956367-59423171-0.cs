    <input type="text" id="txt_firstName"  />
    <input type="text" id="txt_lastName"  />
    <input type="file" id="file_TicketManageMent_AttachFile" multiple  />
    <input type="button" onclick="fnADD()"  />
    
    <script>
    function fnADD(){
           var input = document.getElementById('file_TicketManageMent_AttachFile');
           var files = fileList;
           var formData = new FormData();
    
           for (var i = 0; i != files.length; i++) {
              formData.append("files", files[i]);
           }
              
            formData.append("FirstName ", 'Title');
            formData.append("LastName ", 'Short Description');
    
         $.ajax({
                cache: false,
                type: 'Post',           
                data: formData,
                url: fnApiRequestUri('api/Customer/AddTicket'),
                processData: false,
                contentType: false,
                success: function (xhr, ajaxOptions, thrownError) {
    
                }
            });
    }
    </script>
    
    //C# code
    [Route("AddTicket")]
    [HttpPost]
    [Authorize(Roles = MethodsAuthorization.AllRoles)]
    public async Task<IActionResult> AddTicket(Model _model)
    {
         var files = Request.Form.Files;
         foreach(var item in files)
         {
            var file = item;
            if (file != null)
    		{
    			var fileName = file.FileName;
    			if (System.IO.File.Exists(path + fileName))
    			{
    				fileName = $"{DateTime.Now.ToString("ddMMyyyyHHmmssfff")}-{fileName}";
    			}
    			using (var fileStream = new FileStream(path + fileName, FileMode.Create))
    			{
    				await file.CopyToAsync(fileStream);
    			}
    			reg.Picture = fileName;
    		}
         }
    
    }
    
    public class Model
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public List<IFormFile> Attachments { get; set; }
    }
