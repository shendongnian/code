     var enu = grid.GetEnumerator();
                while (enu.MoveNext())
                {
                    for(int i = 0; i < enu.Current.Count; i++)
                    {
                        enu.Current.RemoveAt(i);
                    }
                }
