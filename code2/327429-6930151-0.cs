        private static void MapBookmarksToFooProperties()
        {
            if (_bookmarkToFooPropertyMapping != null) { return; }  // We already created the mapping.
            _bookmarkToFooPropertyMapping = new Dictionary<string, Func<Foo, string>>();
            // Associate Word document bookmarks to their properties within a Foo object.
            _bookmarkToFooPropertyMapping.Add("dist", foo => foo.Measurment.Distance);
            _bookmarkToFooPropertyMapping.Add("serialNo", foo => foo.SerialNumber);
            // More mapping here
        }     
