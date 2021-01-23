    using System.Data;
    public class CatsDataTable : DataTable
    {
      public CatsDataTable() : base()
      {
        base.TableName = "cats";
        Columns.Add(new DataColumn(SqlTokens.id_cats, typeof(int)));
        Columns.Add(new DataColumn(SqlTokens.owners_id_owners, typeof(int)));
        Columns.Add(new DataColumn(SqlTokens.cats_name, typeof(string)));
        Columns.Add(new DataColumn(SqlTokens.cats_number_of_spots, typeof(int)));
      }
    }
    public class OwnersDataTable : DataTable
    {
      public OwnersDataTable() : base()
      {
        base.TableName = "owners";
        Columns.Add(new DataColumn(SqlTokens.id_owners, typeof(int)));
        Columns.Add(new DataColumn(SqlTokens.owners_name, typeof(string)));
      }
    }
    public class PetsDataSet : DataSet
    {
      public PetsDataSet() : base()
      {
        base.TableName = "pets";
        Tables.Add("cats");
        Tables.Add("owners");
      }
    }
