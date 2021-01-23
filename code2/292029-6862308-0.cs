    	private void convertClubComp(XmlDocument doc)
		{
			XmlNode sessionNode = doc.SelectSingleNode("Session");
			XmlNode playerNode = sessionNode.SelectSingleNode("Players").SelectSingleNode("Player");
			XmlNode groupNode = playerNode.SelectSingleNode("Groups");
			Console.WriteLine(playerNode.Name);
			XmlNode clubsNode = doc.CreateElement("Clubs", "");
			foreach (XmlNode child in groupNode.ChildNodes)
			{
				clubsNode.AppendChild(child.CloneNode(true));
			}
			foreach (XmlAttribute attribute in groupNode.Attributes)
			{
				clubsNode.Attributes.Append((attribute.Clone() as XmlAttribute));
			}
			playerNode.ReplaceChild(clubsNode, groupNode);
			Console.WriteLine(clubsNode.FirstChild.FirstChild.Name);
			Console.WriteLine("!" + playerNode.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.Name);
		}
