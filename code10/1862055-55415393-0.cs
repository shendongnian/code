    public static string dateConverter(DateTime dt)
        {
            long decimalNumber = (long)(dt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return (Convert.ToString(decimalNumber, 16));
        }
    public static void Main(string[] args)
        {
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                string instr;
                Console.WriteLine("Enter the start date");
                instr = Console.ReadLine();
                DateTime.TryParseExact(instr, "yyyy/MM/dd", provider, DateTimeStyles.None, out startDate);
                Console.WriteLine("Enter the end date");
                instr = Console.ReadLine();
                DateTime.TryParseExact(instr, "yyyy/MM/dd", provider, DateTimeStyles.None, out endDate);
                queryFilter = "{_id:{$gte: ObjectId('" + dateConverter(startDate) + "0000000000000000'), $lte: ObjectId('" + dateConverter(endDate) + "ffffffffffffffff')}}";
                string expstring = " --db yourDatabaseName --collection yourCollectionName --type json --query " + queryFilter + " --out yourFilePath --jsonArray";
                Process export = new Process();
                export.StartInfo.FileName = ExportEXEPath;
                export.StartInfo.Arguments = expstring;
                export.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR]: " + ex.Message);
            }
        }
