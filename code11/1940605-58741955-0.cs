    public abstract class ChargeCalculatingFacadeBase<T> where T : ILeasable
    {
        LeasableRepository leasableRepository = new LeasableRepository();
        public ILeasable leasable;
        public void ShowLeasingCharges(int id)
        {
            leasable = leasableRepository.GetLeasable(id);
            var leasingCharge = GetLeasingCharges((T)leasable);
        }
        public abstract int GetLeasingCharges(T leasable);
    }
    public class ChargeCalculatingFacade : ChargeCalculatingFacadeBase<ClubHouse>
    {
        public override int GetLeasingCharges(ClubHouse leasable)
        {
            var property = leasable;
            var areaInSquareFeet = property.AreaInSquareFeet;
            return areaInSquareFeet * 10;
        }
    }
