namespace ToggleAllowBypassKey
{
    using System;
    using DAO = dao;
    public class Program
    {
        private static DAO.DBEngine dbEngine;
        private static DAO.Database database;
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Please enter an MSAccess application path as a parameter!");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to continue ...");
                    Console.ReadLine();
                    return;
                }
                dbEngine = new DAO.DBEngine();
                database = dbEngine.OpenDatabase(args[0]);
                DAO.Property allowBypassKeyProperty = null;
                foreach (dao.Property property in database.Properties)
                {
                    if (property.Name == "AllowBypassKey")
                    {
                        allowBypassKeyProperty = property;
                        break;
                    }
                }
                if (allowBypassKeyProperty == null)
                {
                    allowBypassKeyProperty = database.CreateProperty("AllowBypassKey", DAO.DataTypeEnum.dbBoolean, false, true);
                    database.Properties.Append(allowBypassKeyProperty);
                    Console.WriteLine("AllowBypassKey Property has been added.");
                }
                else
                {
                    allowBypassKeyProperty.Value = !allowBypassKeyProperty.Value;
                    Console.WriteLine("AllowBypassKey is now " + allowBypassKeyProperty.Value + "!");
                }
            }
            finally
            {
                database.Close();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(database);
                database = null;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(dbEngine);
                dbEngine = null;
            }
        }
    }
}
