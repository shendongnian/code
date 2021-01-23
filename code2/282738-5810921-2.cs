    // With 40 million words this can use a lot of space.  You would probably
    // want to create the index on disk and maybe the intermediate processing
    // as well.
    var index = wordList.SelectMany(word => word.ToCharArray(), 
                                    (word, character) => 
                                      new { word, character})
                        .ToLookup(x => x.character, x => x.word);
    var result = letterArray.Distinct()
                            .SelectMany(c => index[c])
                            .GroupBy(word => word)
                            .Where(word => word.Count() > 4)
                            .Select(word => word.Key);
