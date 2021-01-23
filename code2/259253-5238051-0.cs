    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.ServiceModel.Activation;
    using System.Data;
    namespace RestServicePublishing
    {
    [AspNetCompatibilityRequirements(RequirementsMode =     AspNetCompatibilityRequirementsMode.Allowed)]
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    [ServiceContract]
    public class RestService
    {
        
        [OperationContract]
        [WebGet (ResponseFormat = WebMessageFormat.Json)]
        public List<Last_status_by_LongLat> GetState(decimal P1, decimal P2, decimal P3, decimal P4)
        {
            List<Last_status_by_LongLat> Mac = new List<Last_status_by_LongLat>();
            using (ServiceDataContext db = new ServiceDataContext())
            {
                var query = from view node in db.views
                             where table.param > P1 && table.param2 < P2 && table.param2 > P3 && table.param < P4
                             select table;
                Mac = query.ToList();
                
            }
            return Mac;
        }
    }
    }
