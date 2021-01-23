    var excelRowCreator = new ExcelRowCreator(dupespullList);
    var finalRows = excelRowCreator.CreateExcelRows(datapullList);
    // ...
    public class ExcelRowCreator
    {
        /// <summary>
        /// First key is company name, second is location 
        /// and final value is the replacement name.
        /// </summary>
        private readonly IDictionary<string, IDictionary<string, string>> nameReplacements;
        /// <summary>
        /// I don't know what type of objects your initial 
        /// lists contain so replace T with the correct type.
        /// </summary>
        public ExcelRowCreator(IEnumerable<T> replacementRows)
        {
            nameReplacements = CreateReplacementDictionary(replacementRows);
        }
        /// <summary>
        /// Creates ExcelRows by replacing company name where appropriate.
        /// </summary>
        public IEnumerable<ExcelRow> CreateExcelRows(IEnumerable<T> inputRows)
        {
            // ToList is here so that if you iterate over the collection 
            // multiple times it doesn't create new excel rows each time
            return inputRows.Select(CreateExcelRow).ToList();
        }
        /// <summary>
        /// Creates an excel row from the input data replacing
        /// the company name if required.
        /// </summary>
        private ExcelRow CreateExcelRow(T data)
        {
            var name = data.GetString(0);
            var location = data.GetString(1);
            IDictionary<string, string> replacementDictionary;
            if (nameReplacements.TryGetValue(name, out replacementDictionary))
            {
                string replacementName;
                if (replacementDictionary.TryGetValue(location, out replacementName))
                {
                    name = replacementName;
                }
            }
            return new ExcelRow
            {
                Company = name,
                Location = location,
                ItemPrice = data.GetString(4),
                SQL_Ticker = data.GetString(15)
            };
        } 
        /// <summary>
        /// A helper method to create the replacement dictionary.
        /// </summary>
        private static IDictionary<string, IDictionary<string, string>> CreateReplacementDictionary(IEnumerable<T> replacementRows)
        {
            var replacementDictionary = new Dictionary<string, IDictionary<string, string>>();
            foreach (var dupe in replacementRows)
            {
                var name = dupe.GetString(0);
                IDictionary<string, string> locationReplacements;
                if (!replacementDictionary.TryGetValue(name, out locationReplacements))
                {
                    locationReplacements = new Dictionary<string, string>();
                    replacementDictionary[name] = locationReplacements;
                }
                locationReplacements[dupe.GetString(1)] = dupe.GetString(4);
            }
            return replacementDictionary;
        }
    }
