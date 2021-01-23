namespace ToggleAllowBypassKey
{
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
                    Console.WriteLine("Please enter an MS Access application path as a parameter!");
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
                    Console.WriteLine("AllowBypassKey Property has been added. It's Value is '" + allowBypassKeyProperty.Value + "'");
                }
                else
                {
                    allowBypassKeyProperty.Value = !allowBypassKeyProperty.Value;
                    Console.WriteLine("AllowBypassKey set to '" + allowBypassKeyProperty.Value + "'!");
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Exception Message: " + exception.Message);
                Console.WriteLine("Inner Exception:" + exception.InnerException);
            }
            finally
            {
                database.Close();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(database);
                database = null;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(dbEngine);
                dbEngine = null;
                Console.WriteLine();
                Console.WriteLine("Press enter to continue ...");
                Console.ReadLine();
            }
        }
    }
}
