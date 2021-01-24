    private void initializeUnitPerStrip()
            {
               ..
                for (int c = 1; c < totalCol; c++)
                {
                    for (int r = 1; r < totalRow; r++)
                    {
                        UtilitiesModel item = new UtilitiesModel 
                        {
                            Key = "[{c}, {r}]",
                            Tag = "{UTAC_Tags.S7Connection}DB{406},X{frontOffset}.{behindOffset}"
                        };
                        item.PropertyChanged += PropertyChangedFunc;
                        unitPerStrip.Add(item);
                    }
                }
                ItemsControlUnitPerStrip.ItemsSource = unitPerStrip;
            }
