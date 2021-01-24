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
            var hasher = new PasswordHasher<CsvStudent>();
            foreach (var record in records)
            {
                record.PasswordHash = hasher.HashPassword(null, record.Password);
                _context.Users.Add(record);
            }
            _context.SaveChanges();
            return Json(records);
        }
