    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    namespace TestDatamodel
    {
        public partial class DiagnosisPrescriptionManagementEntities
        {
            public override int SaveChanges()
            {
                ObjectContext context = ((IObjectContextAdapter)this).ObjectContext;
    
                foreach (ObjectStateEntry entry in
                         (context.ObjectStateManager
                           .GetObjectStateEntries(EntityState.Added | EntityState.Modified)))
                {                    
                    if (!entry.IsRelationship)
                    {
                        CurrentValueRecord entryValues = entry.CurrentValues;
                        if (entryValues.GetOrdinal("ModifiedBy") > 0)
                        {
                            HttpContext currentContext = HttpContext.Current;
                            string userId = "nazrul";
                            DateTime now = DateTime.Now;
    
                            if (currContext.User.Identity.IsAuthenticated)
                            {
                                if (currentContext .Session["userId"] != null)
                                {
                                    userId = (string)currentContext .Session["userId"];
                                }
                                else
                                {                                    
                                    userId = UserAuthentication.GetUserId(currentContext .User.Identity.UserCode);
                                }
                            }
    
                            if (entry.State == EntityState.Modified)
                            {
                               entryValues.SetString(entryValues.GetOrdinal("ModifiedBy"), userId);
                               entryValues.SetDateTime(entryValues.GetOrdinal("ModifiedDate"), now);
                            }
    
                            if (entry.State == EntityState.Added)
                            {
                                entryValues.SetString(entryValues.GetOrdinal("CreatedBy"), userId);
                                entryValues.SetDateTime(entryValues.GetOrdinal("CreatedDate"), now);
                            }
                        }
                    }
                }
    
                return base.SaveChanges();
            }
        }
    }
