    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using PIMP.Web.TestForum.DataObject.Forum;
    using PIMP.Web.TestForum.DataObject.Account;
    using System.Text.RegularExpressions;
    using PIMP.Web.TestForum.DataObject;
    
    namespace PIMP.Web.TestForum.Models
    {
        public class ThreadModel<T> : PagedList<T>
        {
