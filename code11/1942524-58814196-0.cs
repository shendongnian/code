            for (int i = 0; i< list.Count-1; i++)
            {
               NDocList.Add(list[i].DocumentiOrigine.Split(new string[] { " N. " }, StringSplitOptions.None)[1]
                .Split()[0]
                    .Trim());
            }
