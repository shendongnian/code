        public IEnumerable<ImportField> CreateFields(HttpPostedFileBase file)
        {
            if (file == null) throw new ArgumentNullException("file");
            return ExtractFromFile(file);
        }
        private IEnumerable<ImportField> ExtractFromFile(HttpPostedFileBase file)
        {
            using (var reader = new StreamReader(file.InputStream))
            {
                var firstLine = reader.ReadLine();
                var columns = firstLine.Split(new[] { ',' });
                for (var i = 0; i < columns.Length; i++)
                {
                    yield return new ImportField(columns[i], i);
                }
            }
        }
