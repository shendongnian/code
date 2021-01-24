     public class GetHousesHandler : IRequestHandler<GetHouses, IEnumerable<House>>
        {
            private readonly IDbConnection _connection;
    
            public GetHousesHandler(IDbConnection connection)
            {
                _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            }
    
            public async Task<IEnumerable<House>> Handle(GetHouses request, CancellationToken cancellationToken)
            {
                var sql = $@"
                    SELECT StreetName AS {nameof(House.StreetName)}
                      , Number AS {nameof(House.Number)}
                    FROM dbo.HouseView
    				WHERE Number = @Number;";
    
                var param = new
                {
                    request.Number,
                };
    
                return await _connection.QueryAsync<House>(
                    sql: sql,
                    param: param
                    );
            }
        }
