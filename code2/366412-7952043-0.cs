                 List<ArrayList> temp = new List<ArrayList>(t.Count);
                    for (int i = 0; i < t.Count; i++)
                    {
                        ArrayList al = t[i];
                        if (Convert.ToInt32(al[0]) != Convert.ToInt32(ImgArry[0]))
                            temp.Add(al);
                    }
                    t = temp;
