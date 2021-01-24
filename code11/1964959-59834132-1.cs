    using Microsoft.AspNetCore.Mvc;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using dto = v2.Models;
    using mFilter = v2.AllowCrossSiteJsonAttribute;
    
    namespace v2.Controllers
    {
        [AllowCrossSiteJson]
