    public static string GetFileSize(this FileInfo fi)
    {
      long Bytes = fi.Length;
 
      if (Bytes >= 1073741824)
      {
         Decimal size = Decimal.Divide(Bytes, 1073741824);
         return String.Format("{0:##.##} GB", size);
      }
      else if (Bytes >= 1048576)
      {
         Decimal size = Decimal.Divide(Bytes, 1048576);
         return String.Format("{0:##.##} MB", size);
      }
      else if (Bytes >= 1024)
      {
         Decimal size = Decimal.Divide(Bytes, 1024);
         return String.Format("{0:##.##} KB", size);
      }
      else if (Bytes > 0 & Bytes < 1024)
      {
         Decimal size = Bytes;
         return String.Format("{0:##.##} Bytes", size);
      }
      else
      {
         return "0 Bytes";
      }
     }
