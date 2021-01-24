    var query = notesList.GroupBy(x => x.Text)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .Select(y => new { Element = y, Index = Array.FindIndex<Notes>(notesList.ToArray(), t => t.Text ==y)  })
                .ToList();
            var filteredList = new List<Notes>();
            foreach (var duplicate in query)
            {
                filteredList = notesList.Where((n, index) => index < duplicate.Index + 1).ToList();
                var newElems = notesList.Where((n, index) => index > duplicate.Index + 1).Select(t =>
                    new Notes {Level = t.Level == 1 ? 1 : t.Level - 1, Text = t.Text});
                filteredList.AddRange(newElems);
            }
