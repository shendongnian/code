    [HttpPost]
    public ActionResult Index(HttpPostedFileBase file)
    {
        if (file != null && file.ContentLength > 0)
        {
            var fileName = Path.GetFileName(file.FileName);
            var extension = Path.GetExtension(fileName);
            var document = new byte[file.InputStream.Length];
            file.InputStream.Read(document, 0, document.Length);
            if (string.Equals(".pdf", extension, StringComparison.OrdinalIgnoreCase))
            {
                using (var conn = new SqlConnection(SomeConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "INSERT INTO Documents (document) VALUES (@document);";
                    cmd.Parameters.Add("@document", SqlDbType.Binary, 20).Value = document;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        return View();
    }
