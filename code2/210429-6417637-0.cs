    public interface IAppSlotContainer
    {
        void relevant_Method_When_ObjectIsAppSlot();
    }
    public interface IEmptySlotContainer
    {
        void relevant_Method_When_ObjectIsEmptySlot();
    }
    public class EmptyWrapper : AppWrapper, IAppSlotContainer, IEmptySlotContainer
    {
    public EmptyWrapper(EmptySlot emptySlot) : base()
    {
        this._emptySlot = emptySlot;
    }
    public override string Id
    {
        get { return _emptySlot.AgendaId; }
    }
    public void relevant_Method_When_ObjectIsEmptySlot()
    {
    }
    public void relevant_Method_When_ObjectIsAppSlot()
    {   
    }
