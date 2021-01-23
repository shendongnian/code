    using System.Data.SqlClient;
    
    namespace WebApplication.Data.DataSet1TableAdapters
    {
        public partial class QueriesTableAdapter
        {
            public SqlCommand aspnet_Membership_CreateUser_Command
            {
                get { return (SqlCommand) CommandCollection[0]; }
            }
        }
    }
