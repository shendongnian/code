     private IEnumerable<IEnumerable<T>> SplitMaintainingOrder<T>(IEnumerable<T> list, int columnCount)
                    {
                        var elementsCount = list.Count();
                        int rowCount = elementsCount / columnCount;
                        int noOfCells = elementsCount % columnCount;
                        int finalRowCount = rowCount;
                        if (noOfCells > 0)
                        {
                            finalRowCount++;
                        }
                        var toreturn = new List<IEnumerable<T>>();
                        var pushto = 0;
                        for (int j = 0; j < columnCount; j++)
                        {
                            var start = j;
                            int i = 0;
                            var end = i;
                            for (i = 0; i < finalRowCount; i++)
                            {
                                if ((i < rowCount) || ((i == rowCount) && (j < noOfCells)))
                                {
                                    start = j;
                                    end = i;
                                }
                            }
                            toreturn.Add(list.Skip(pushto).Take(end + 1));
                            pushto += end + 1;
                        }
                        return toreturn;
                    }
    
