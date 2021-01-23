    IList<FileInfo> selectionFileOrder = new List<FileInfo>();
    foreach(FileInfo item in dateAllOrder)
    {
         if (item.LastAccessTime.Month == DateTime.Now.Month)
         {
              selectionFileOrder.Add(item);
              // Console.Write("{1}. {0}", dateAllOrder[index].Name, index);
              // Console.Write(" ({0}) ", dateAllOrder[index].Length);
              Console.WriteLine();
         }
    }
