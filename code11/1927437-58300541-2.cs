    public FileContentResult GetRejects()
    		{
    			return File(WorksheetTools.GetRejectsExcelFile(userId),
    				"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
    				string.Concat("Rejects.", DateTime.Now.ToString("ddMMyyyy.HHmmss"), ".xlsx"));
    		}
