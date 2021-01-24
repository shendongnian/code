    using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var queryResult = connection.Query<ResponseBody>(@"SELECT 
                        s.Name as StudioName,
                        c.Name as CityName,
                        a.Street as Street
                    FROM
                        Studios as s
                    INNER JOIN
                        Cities as c ON s.Id = c.StudioId
                    INNER JOIN
                        Addresses as a ON c.Id = a.CityId
                    where s.Name = 'Studio1' and c.Name = 'Wuxi' and a.Number = '101'");
                    return queryResult ;
                }
