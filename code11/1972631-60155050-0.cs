    var query = notesList.GroupBy(x => x.Text)
                    .Where(g => g.Count() > 1)
                    .Select(y => y.Key)
                    .Select(y => new { Element = y, Index = Array.FindIndex<Notes>(notesList.ToArray(), t => t.Text ==y)  })
                    .ToList();
    
                if (query.Count> 0)
                {
                    foreach (var duplicate in query)
                    {
                        notesList.RemoveAt(duplicate.Index+1); //remove the next duplicate
                        //now adjust the level values for the next two items
                        if (duplicate.Index+1 < notesList.Count)
                        {
                            notesList[duplicate.Index + 1].Level--;
                        }
                        if (duplicate.Index + 2 < notesList.Count)
                        {
                            notesList[duplicate.Index + 2].Level--;
                        }
                    }
                }
