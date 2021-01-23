                    *if (count % 2 > 0)
                    {
                        result.Add(new Coordinate());
                        result[itemIndex].Latitude = **(double)reader.Value;**
                    }
                    else
                    {
                        result[itemIndex].Longitude = **(double)reader.Value;**
                    }*
