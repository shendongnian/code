    using System.Web.Script.Serialization;
        public string getValuesJson()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MyDBEntities ctx = new MyDBEntities();
            
            var myValues = (from m in ctx.TestEntity
                           where (m.id == 22)
                           select m).ToList();
        
            return js.Serialize(myValues);
        }
