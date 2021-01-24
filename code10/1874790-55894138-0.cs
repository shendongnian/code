    for (int i = 0; i < dynamicList.Count; i++)
                        {
                            dynamicList[i].GetType().GetProperty(first)
                                .SetValue(dynamicList[i], ((double)(dynamicList[i][first])).ToString("N", CultureInfo.CreateSpecificCulture("fr")), null);
    
                            dynamicList[i].GetType().GetProperty(two)
                                .SetValue(dynamicList[i], ((double)(dynamicList[i][first])).ToString("N", CultureInfo.CreateSpecificCulture("fr")), null);
                        }
