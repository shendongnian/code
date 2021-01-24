    public async Task<IActionResult> ImportUsers(IFormFile file)
        {
            var data = new MemoryStream();
            await file.CopyToAsync(data);
            data.Position = 0;
            TextReader reader = new StreamReader(data);
            var csvReader = new CsvReader(reader ,new CsvHelper.Configuration.Configuration
            {
                HasHeaderRecord = true, //Gets or sets a value indicating if the CSV file has a header record. Default is true.
                HeaderValidated = null,//Gets or sets the function that is called when a header validation check is ran
                MissingFieldFound=null //Gets or sets the function that is called when a missing field is found.
            });
            var records = csvReader.GetRecords<CsvStudent>().ToList();
            foreach (var item in records)
            {
               //check if the user has been existing in db 
                var user = await _userManager.FindByNameAsync(item.Name);
                if (user == null)
                {
                    user = new CsvStudent
                    {
                        Name = item.Name,
                        Number = item.Number,
                        Course = item.Course,
                        UserName = item.Name
                    };
                    await _userManager.CreateAsync(user, item.Password);
                }
            }
             return Json(records);
        }
