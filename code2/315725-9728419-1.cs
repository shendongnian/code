    				csNodeList _Copyrights = new csNodeList();
					resource = System.Windows.Application.GetResourceStream(new Uri(@"Design/sampledata.xml", UriKind.Relative));
					streamReader = new StreamReader(resource.Stream);
					serializer = new XmlSerializer(typeof(csNodeList));
					_Copyrights = (csNodeList)serializer.Deserialize(streamReader);
