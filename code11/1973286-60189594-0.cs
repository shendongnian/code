csharp
public static async Task<Request> GetByRequestId(long id)
{
    string sql = "SELECT * FROM Request WHERE ID = @id";
    using (var connection = new SqlConnection(_connectionString))
    {
        // Need dynamic here because of the conversion of the Status column as an enum.
        // If someone has a better way...
        dynamic dynamicRequest = await connection.QueryFirstOrDefaultAsync(sql, new { id });
        if (dynamicRequest == null) { return default; }
        var request = new Request
        {
            Id     = dynamicRequest.ID,
            Status = JsonConvert.DeserializeObject<RequestStatus>($"\"{dynamicRequest.Status}\""),
        };
        return request;
    }
}
