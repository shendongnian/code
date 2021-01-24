    public class ResponseBody
        {
            public string StudioName { get; set; }
            public string CityName { get; set; }
            public string Street { get; set; }
        }
        public async Task<IActionResult> AsyncSBSystemApps()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(@"SELECT 
                        s.Name as StudioName,
                        c.Name as CityName,
                        a.Street as Street
                    FROM
                        Studios as s
                    INNER JOIN
                        Cities as c ON s.Id = c.StudioId
                    INNER JOIN
                        Addresses as a ON c.Id = a.CityId
                    where s.Name = 'Studio1' and c.Name = 'Wuxi' and a.Number = '101'
                    For JSON PATH  ", connection);
                    await connection.OpenAsync();
                    var result = command.ExecuteScalar().ToString();
                     // Deserializing json data to object 
                    var getModel = JsonConvert.DeserializeObject<List<ResponseBody>>(result);
                    //return ...
                }
            }
        }
