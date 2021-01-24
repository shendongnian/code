    using System.Data.SqlClient;
    using System.Threading.Tasks;
    namespace My.Softwares.Namespace.Model {
        public partial class DatabaseEntities {
            public virtual Task<int> CancelCurrentForkliftDeliveryAsync(int? iD_Carrier) {
                return Database.ExecuteSqlCommandAsync(
                    "exec dbo.CancelCurrentForkliftDelivery @ID_Carrier",
                    new SqlParameter("@ID_Carrier", iD_Carrier)
                );
            }
        }
    }
