    private void SaveAs(Excel.Workbook WorkBook, string FileName)
		{
			m_Saving = true;
			try
			{
				if (Global.CreatingCopy)
					this.ExcelApp.DisplayAlerts = false;
				WorkBook.SaveAs(FileName);
			}
			finally
			{
				m_Saving = false;
				if (this.ExcelApp.DisplayAlerts == false)
					this.ExcelApp.DisplayAlerts = true;
            }
		}
