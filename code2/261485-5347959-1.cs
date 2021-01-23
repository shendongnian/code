    for (int i = 0; i < tempPaths.Count; i++)
                    {
                        //Getting the original names of the images
                        int pLength = rawStorePath.Length;
                        string something = tempPaths[i].Remove(0, pLength);
                        if (!_tfileName.ContainsKey(tempPaths[i]))
                        { _tfileName.Add(tempPaths[i], something); }
                    }
