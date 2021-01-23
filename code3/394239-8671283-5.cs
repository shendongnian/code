      private void RecurseElements(IEnumerable<XElement> descendants, int level)
      {
         if (descendants == null || !descendants.Any()) return;
         foreach (var d in descendants)
         {
            string levelName = d.Attribute("name").Value;
            System.Diagnostics.Debug.Print(string.Format("Level name {0}", levelName));
            var x = d.Descendants().ToList();
            var descendantElms = d.Descendants(string.Format("level{0}", level+1)).ToList();
            RecurseElements(descendantElms, level+1);
         }
      }
