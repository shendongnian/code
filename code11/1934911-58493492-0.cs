            while (list != null)
            {
                if (item.CompareTo(temp.Data) < 0)
                {
                    newList.AppendItem(item);
                    // and then...?
                }
                else
                {
                    newList.AppendItem(temp.Data);
                    temp = temp.Next;
                }
                // never-ending loop
            }
