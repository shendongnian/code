    public enum Slot { Head, Torso, Legs }
	public interface ISlot
	{
		Slot SlotType { get; }
	}
	public class Torso : ISlot
	{
		public Slot SlotType { get => Slot.Torso; }
	}
	public class Slots
	{
		private Dictionary<Slot, ISlot> _slots { get; set; } = new Dictionary<Slot, ISlot>();
		public void Add(Slot slot, ISlot slotClass)
		{
			if (slot == slotClass.SlotType)
			{
				_slots.Add(slot, slotClass);
			}
			else
			{
				throw new Exception("Invalid type.");
			}
		}
	}
