string resName = null;
foreach (string resourceName in Assembly.GetExecutingAssembly().GetManifestResourceNames())
{
   Console.WriteLine("Assembly.GetExecutingAssembly().GetManifestResourceNames() [" + resourceName + "] ");
   if (resourceName.Contains("my.Assembly"))
   {
      resName = resourceName;
      Console.WriteLine("CurrentDomain Assembly my.Assembly [" +  "] Resource name [" + resName + "]");
    }
}
Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(resName);
if (s != null)
{
    byte[] data = new BinaryReader(s).ReadBytes((int)s.Length);
    Assembly a = Assembly.Load(data);
    newAppDomain.Load(data);
     foreach (Assembly cdAssem in newAppDomain.GetAssemblies())
     {
        Console.WriteLine("newAppDomain Assembly 2 [" + cdAssem.GetName().FullName + "]");
      }
}
I can see that the assembly is part of my new AppDomain:
> newAppDomain Assembly 2 [mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]
> newAppDomain Assembly 2 my.Assembly Version=19.1.7243.19014, Culture=neutral, PublicKeyToken=null]
But using CreateInstanceAndUnwrap()  still fails saying it can't find my.Assembly.dll.  I am wondering if the only way one can load an assembly into the AppDomain is by loading it from the Base Directory?
