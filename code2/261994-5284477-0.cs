            List<Item> combinedList = new List<Item>(list1.Count);
            for (int i = 0; i < list1.Count; i++)
            {
                combinedList.Add(new Item()
                {
                    Value1 = list1[i],
                    Value2 = list2[i],
                    Value3 = list3[i]
                });
            }
