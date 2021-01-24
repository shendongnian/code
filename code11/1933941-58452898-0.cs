using var ms=new MemoryStream();
using( BinaryWriter writer = new BinaryWriter(ms))
{  
  writer.Write(new String('0',3));        
}
var b=ms.ToArray();
Produces 
3, 48,48,48
Use `StreamWriter` or `File.WriteAllText` instead. The default encoding used is UTF8 so there's no need to specify an encoding or try to change anything :
using (FileStream fs = new FileStream( Path.Combine(Application.persistentDataPath , savedName+".json"), FileMode.Create))
using(var writer=new StreamWriter(fs))
{
        writer.Write(jsons);
}
or 
var path=Path.Combine(Application.persistentDataPath , savedName+".json")
using(var writer=new StreamWriter(path))
{
        writer.Write(jsons);
}
