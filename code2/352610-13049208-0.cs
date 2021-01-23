       public void SortWs()
       {
            List<Worksheet> for_sort = new List<Worksheet>();
            foreach (Worksheet ws in wb.Worksheets)
            {
                for_sort.Add(ws);
            }
            for_sort.Sort(delegate(Worksheet wst1, Worksheet wst2)
            {
                return wst1.Name.CompareTo(wst2.Name);//sort by worksheet's name
            });
            Worksheet ws1, ws2;
            for (int i = 0; i < for_sort.Count; i++)
            {
                for (int j = 1; j <= wb.Worksheets.Count; j++)
                {
                    ws1 = (Worksheet)wb.Worksheets[j];
                    if (for_sort[i].Name == ws1.Name)
                    {
                        ws2 = (Worksheet)wb.Worksheets[i+1];
                        ws1.Move(ws2, Type.Missing);
                    }
                }
            }
        }
