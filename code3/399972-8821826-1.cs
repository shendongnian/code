    Thread 1                              Thread 2
    // both threads access the singleton, but you are "safe" because you locked
1.  var loc1 = Params.Localizations;      var loc2 = Params.Localizations;
    // do stuff                           // thread 2 calls the same property...
2.  var value = loc1.ChunkSize;           var chunk = LC.Loc("params.chunksize");
    // invalidate                         // ...there is a slight pause here...
3.  loc1.RebuildLocalizations();
                                          // ...and gets the wrong value
4.                                        var value = chunk.To<int>();
