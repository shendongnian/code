        [HttpPost]
        public IActionResult SelectFilesToProcess(int Id, FileSelectionToProcess Model)
        {
            DateTime dateAdded = DateTime.Now;
            DateTime fileDateFromTicks;
            string timeSpan;
            //Foreach date, import to CurrMo
            foreach (var fileDate in Model.FileDatesToProcess)
            {
                if(fileDate.IsChecked)
                {
                    timeSpan = fileDate.FileDateTick.ToString();
                    fileDateFromTicks = new DateTime(long.Parse(timeSpan));
                    _importProcessing.InsertPOSImportedToCurrMo(Model.ConnectionString, dateAdded, fileDateFromTicks);
                }                
            }
            return RedirectToAction("Processing", new { Id, IsProcessing = false });
        }
