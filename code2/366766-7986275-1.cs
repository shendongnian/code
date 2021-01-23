	public override void SaveToDisk()
	{
		byte[] keys = { (byte)0xd0, (byte)0xcf, (byte)0x11, (byte)0xe0, (byte)0xa1, (byte)0xb1, (byte)0x1a, (byte)0xe1 };
		int offset = Utils.SearchBytes(m_RawOleObject, keys);
		using (MemoryStream ms = new MemoryStream(strip(m_RawOleObject, offset)))
		{
			CompoundFile cf = new CompoundFile(ms, UpdateMode.ReadOnly, true, true);
			m_filename = GetNextAvailableFilename(System.IO.Path.Combine(STOREPATH, Utils.CombineFilenameWithExtension(Filename, m_extension)), 0);
			using (var fs = new FileStream(m_filename, FileMode.Create))
			{
				cf.Save(fs);
				cf.Close();
			}
		}
		//Workbook would be saved as hidden in previous step
		Microsoft.Office.Interop.Excel.Application xlApp = null;
		Microsoft.Office.Interop.Excel.Workbook xlWb = null;
		try
		{
			xlApp = new Microsoft.Office.Interop.Excel.Application();
			xlWb = xlApp.Workbooks.Open(m_filename);
			xlWb.CheckCompatibility = false;
			foreach (Window wn in xlApp.Windows)
			{
				wn.Visible = true;
			}
			xlWb.Save();
			xlWb.Close();
		}
		catch (Exception e)
		{
			//TODO: Log error and continue
		}
		finally
		{
			if (xlWb != null)
				Marshal.ReleaseComObject(xlWb);
			if (xlApp != null)
				Marshal.ReleaseComObject(xlApp);
			xlApp = null;
		}
	}
