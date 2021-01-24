    public partial class TipManagerDBEntities : DbContext
    {
        public TipManagerDBEntities()
            : base(@"metadata=res://*/DBModel.csdl|res://*/DBModel.ssdl|res://*/DBModel.msl;provider=System.Data.SqlClient;provider connection string=';data source=DESKTOP-GNG12RP\SQLEXPRESS;initial catalog=TipManagerDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework';")
        {
        }
    
