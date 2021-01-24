			//Write XML
				List<UO> lstUO = new List<UO>();
				using (StreamWriter writer = new StreamWriter(FilePath,false))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(List<UO>));
					serializer.Serialize(writer, lstUO);
					writer.Close();
				}
				//Read XML
				
                using (FileStream stream = File.OpenRead(FilePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<UO>));
                    List<UO> dezerializedList = (List<UO>)serializer.Deserialize(stream);
                    stream.Close();
                }
							
			    public class UO
				{
					public string input { get; set; }
					public string input1 { get; set; }
				}
					 
