     using System.Runtime.InteropServices; // For Marshal
     ...
     // Marshal.SizeOf - length in bytes (we don't have int.Length in C#)
     StringBuilder hex = new StringBuilder(Marshal.SizeOf(array[1]) * 2);
     // BitConverter.GetBytes - byte[] representation
     foreach (byte b in BitConverter.GetBytes(array[1]))
       hex.AppendFormat("{0:x2}", b);
     // You can well get "9c061600" (reversed bytes) instead of "0016069c"
     // if BitConverter.IsLittleEndian == true 
     string value = hex.ToString(); 
