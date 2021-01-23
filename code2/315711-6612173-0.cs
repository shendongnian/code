     foreach (XElement task in XTasks.Elements())
     {
         XElement userNode = XUsers.Elements().Where(
            e => e.Attribute("id").Value == task.Attribute("ownerId").Value).FirstOrDefault();
         if (userNode != null)
         {
            task.Attribute("ownerName").SetValue(userNode.name);
         }
     }
