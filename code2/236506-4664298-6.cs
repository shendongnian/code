			List<ItemType> list = new List<ItemType>();
			list.Add(new Clubs() { ClubsArray = new Club[] { new Club() { Num = 0, ClubName = "Some Name", ClubChoice = "Something Else" } } });
			list.Add(new Gift() { Val = "MailGreeting", GiftName = "MailGreeting", GiftDescription = "GiftDescription", GiftQuanity = 1});
			order order = new order();
			order.ItemTypes = list.ToArray();
			XmlSerializer serializer = new XmlSerializer(typeof(order));
			StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Stuff.xml");
			serializer.Serialize(sw, order);
			sw.Close();
