using (TextReader reader = File.OpenText(@"D:\flatfile.txt"))
{
  string line = reader.ReadLine();
  string code = line.Substring(0, 5);
  // Add your structures factory realization 
  Type type = Factory.GetStructureByCode(code);
                
  string typeInitializtion = line.Substring(5, (line.Length - 5));
  byte[] bytes = Encoding.UTF8.GetBytes(typeInitializtion);
  //Allocate amount of memoty
  IntPtr safePrt = Marshal.AllocCoTaskMem(Marshal.SizeOf(type));
  //Copy 'bytes' byte buffer into memmory allocated
  Marshal.Copy(bytes, 0, safePrt, bytes.Length);
  //Map structure to pointer
  var myStructure = Marshal.PtrToStructure(safePrt, type);
}
