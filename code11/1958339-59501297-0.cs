public interface IRepository
{
   IEnumerable<MyModel> GetAll();
   void Save(IEnumerable<MyModel> data);
}
Then, you will have:
public class CsvRepository: IRepository
{
   IEnumerable<MyModel> GetAll()
  {
    // data from Csv
  }
   void Save(IEnumerable<MyModel> data) 
  {
   // save to csv
  }
}
public class DbRepository: IRepository
{
   IEnumerable<MyModel> GetAll()
  {
    // data from db
  }
   void Save(IEnumerable<MyModel> data) 
  {
   // save to db
  }
}
And then you can do sth like:
var csv = new CsvRepository();
var db = new DbRepository();
db.Save(csv.GetAll());
