      private void RecurseNodes(IEnumerable<XElement> descendants)
      {
         foreach (var d in descendants)
         {
            string levelName = d.Attribute("name").Value;
            System.Diagnostics.Debug.Print(string.Format("Level name {0}", levelName));
            RecurseNodes(d.Descendants());
         }
      }
