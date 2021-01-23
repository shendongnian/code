     var selectionFileOrder = new List<FileInfo>();
     for (int index = 0; index < dateAllOrder.Length; index++)
     {
          if (dateAllOrder[index].LastAccessTime.Month == DateTime.Now.Month)
          {
               selectionFileOrder.Add(dateAllOrder[index]);
          }
      }
