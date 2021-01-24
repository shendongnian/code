      locations= locations.OrderBy(x => x.Address).ToList();
      var orderedPeopleList=new List<Person>();
      for (var i = 0; i < locations.Count(); i++)
      {
            peopelOrderedList.Add(people.FirstOrDefault(x => x.Address == locations[i].Address && peopelOrderedList.All(c => c.Name != x.Name)));
      }
      peopelOrderedList.RemoveAll(x => x == null);
