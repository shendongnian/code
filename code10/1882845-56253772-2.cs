    using System.Collections.Generic;
    using System.Text;
    using System.Web.Mvc;
    using System.Data.Entity;
    public class Car
    {
        public string Model{ get; set; }
        public string Color{ get; set; }
        public int Year { get; set; }
    }
    var sql = new StringBuilder();
    sql.Append(" SELECT Model, Color, Year ");
    sql.Append(" FROM   TableCar ");
    var list = someDBCONTEXT.Database.SqlQuery<Car>(sql.ToString()).ToList();
