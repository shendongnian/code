    using (var e = listOfDictionaries.GetEnumerator()) {
      var hasMore = e.MoveNext();
      while (hasMore) {
        var dictionary = e.Current;
        ...
        hasMore = e.MoveNext();
        if (!hasMore) {
          // Inside this if block dictionary is the last item in listOfDictionaries
        }
      }
    }
