            /******************************************************************************
     * Function to return Item id which is stored in Database 
     * ***************************************************************************/
        public static async Task<IEnumerable<string>> Item_Id()
        {
            var items = new List<string>();
            using (var cnn = new SqlConnection(@"Data Source=************;Initial Catalog=*************;User ID=*******************;Password=*************"))
            {
                await cnn.OpenAsync().ConfigureAwait(false);
                var Query = "select col_item_id from tbl_Zoho_Items_data";
                using (var command = new SqlCommand(Query, cnn))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        while (await reader.ReadAsync().ConfigureAwait(false)) items.Add(reader["col_item_id"].ToString());
                    }
                }
                return items;
            }
        }
        /***********************************************************
     * Main program to fecth serial Numbers based on the Item_id
     * specified in the API
     ***********************************************************/
        public static async Task Main()
        {
            string strResponse = string.Empty; //to collect json Data
            IEnumerable<string> items = await Item_Id().ConfigureAwait(false); //fetching item id from function Item_id
            Parallel.ForEach(items, async item =>
            {
                Console.WriteLine(item + "Serial numbers for particular Item id are given below");
                var k = 1; //variable to navigate to different pages
                while (1 > 0)
                {
                    /****************************************************************
                     * Requesting API with item id as parameter
                     * *************************************************************/
                    var request = (HttpWebRequest) WebRequest.Create(@"https://books.zoho.com/api/v3/items/serialnumbers?per_page=200&item_id=" + item + "&organization_id=***********&page=" + k);
                    request.Method = "GET";
                    request.Headers.Add("Authorization", "*************************");
                    using (var response = (HttpWebResponse) await request.GetResponseAsync().ConfigureAwait(false))
                    {
                        if (response.StatusCode != HttpStatusCode.OK) throw new ApplicationException("Error code in response recieved: " + response.StatusCode.ToString());
                        using (Stream resStream = response.GetResponseStream())
                        {
                            if (resStream != null)
                                using (var streamReader = new StreamReader(resStream))
                                {
                                    strResponse = await streamReader.ReadToEndAsync().ConfigureAwait(false);
                                }
                        }
                    }
                    string Jsoncontent = strResponse;
                    /***************************************************************
                     * Deserializing Json Data into C# objects
                     * ************************************************************/
                    var root = JsonConvert.DeserializeObject<RootObject>(Jsoncontent);
                    if (root.serial_numbers.Count != 0)
                        foreach (SerialNumber serial in root.serial_numbers)
                            Console.WriteLine(serial.serialnumber);
                    else
                        break;
                    k++;
                    Console.WriteLine("Page= " + k);
                }
            });
        }
