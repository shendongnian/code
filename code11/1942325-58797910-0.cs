using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
   class Program
   {
       static void Main(string[] args)
       {
           //toturial obj = new toturial();
           //obj.ID = 1;
           //obj.name = "MrLotfi";
           //IFormatter formatter = new BinaryFormatter();
           //Stream stream = new FileStream("E:\\example.txt", FileMode.Create, FileAccess.ReadWrite);
           //formatter.Serialize(stream,obj);
           //stream.Close();
           Tutorial obj = new Tutorial();
           obj.ID = 1;
           obj.Name = ".Net";
           IFormatter formatter = new BinaryFormatter();
           Stream stream = new FileStream(@"E:\ExampleNew.txt", FileMode.Create, FileAccess.Write);
           formatter.Serialize(stream, obj);
           stream.Close();
           SqlConnection conn = new SqlConnection("Your SQL Connection String");
           conn.Open();
           StringBuilder str = new StringBuilder();
           str.AppendLine("DECLARE @tImage AS VARBINARY(MAX)");
           str.AppendLine(@"SELECT @tImage = CAST(bulkcolumn AS VARBINARY(MAX)) FROM OPENROWSET( BULK 'E:\ExampleNew.txt', SINGLE_BLOB ) AS x");
           str.AppendLine(@"INSERT INTO TblPhotos (ID, Name, Images) SELECT NEWID(), 'E:\ExampleNew.txt',@tImage");
           SqlCommand cmd = new SqlCommand(str.ToString(), conn);
           cmd.ExecuteNonQuery();
           Console.WriteLine("Image Saved Successfully...");
           stream = new FileStream(@"E:\ExampleNew.txt", FileMode.Open, FileAccess.Read);
           Tutorial objnew = (Tutorial)formatter.Deserialize(stream);
           Console.WriteLine(objnew.ID);
           Console.WriteLine(objnew.Name);
           Console.ReadKey();
       }
   }
   [Serializable]
   public class Tutorial
   {
       public int ID;
       public string Name;
   }
}
