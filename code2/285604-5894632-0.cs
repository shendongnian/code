		public static Enums.Status WriteListToXML<T>(string outputPath, List<T> inboundList)
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(inboundList.GetType());
				using (StreamWriter streamWriter = System.IO.File.CreateText(outputPath))
				{
					xmlSerializer.Serialize(streamWriter, inboundList);
				}
				return Enums.Status.Success;
			}
			catch (Exception ex)
			{
				return Enums.Status.Failure;
			}
		}
