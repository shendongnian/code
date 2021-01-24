    for (int i = 0; i < nameList.Count; i++)
            {
                for (int j = 0; j < wiznzList.Count; j++)
                {
                    string a = nameList[i];
                    string c = wiznzList[j].ProductName;
                    if (string.Equals(a, c))
                    {
                        wizNzPriceList.Add(wiznzList[j].Price);
                        break;
                    }
                    else if (j == (wiznzList.Count - 1))
                    {
                        wizNzPriceList.Add("No Product");
                    }
                }
            }
