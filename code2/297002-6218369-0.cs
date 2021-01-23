            try
			{
				byte[] xmlContentInBytes = new System.Text.UnicodeEncoding().GetBytes(xmlContent);
				System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding(false, true);
				utf8.GetChars(xmlContentInBytes);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
