    class Program
    {
        static void Main(string[] args)
        {
            DataTable result = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT name, value FROM specifications", connection))
                {
                    using (SqlDataAdapter reader = new SqlDataAdapter(command))
                    {
                        reader.Fill(result);
                    }
                }
            }
            List<string> foundNullSpecifications = result.Rows.OfType<DataRow>().Select(x => new Specification
            {
                Name = (string)x["name"],
                Value = x["value"]
            }).Where(x => x.Value == null).Select(x => x.Name).ToList();
        }
    }
    public class Specification
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
