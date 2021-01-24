    public class StudentPaginatedResultContractResolver : StudentContractResolver
    {
        public StudentPaginatedResultContractResolver()
        {
            PropertyMappings.Add(nameof(StudentPaginatedResult.Students), "Result");
        }
    }
