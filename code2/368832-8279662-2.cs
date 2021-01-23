    public class UnitOfWorkLifestyleManager : AbstractLifestyleManager
    {
        private string PerUnitOfWorkObjectID = "UnitOfWorkLifestyleManager_" + Guid.NewGuid().ToString(); 
        public override object Resolve()
        {
            if(UnitOfWork.Current.Items[PerUnitOfWorkObjectID] == null)
            {
                // Create the actual object
                UnitOfWork.Current.Items[PerUnitOfWorkObjectID] = base.Resolve();  
            }
            return UnitOfWork.Current.Items[PerUnitOfWorkObjectID];
        }
        public override void Dispose()
        { 
        }
    }
