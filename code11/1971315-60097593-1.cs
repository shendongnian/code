    public enum Slot { Head, Torso, Legs }
	public interface IArmor
	{
		Slot SlotType { get; }
	}
	public class Torso : IArmor
	{
		public Slot SlotType { get => Slot.Torso; }
	}
	public class Slots
	{
		private Dictionary<Slot, IArmor> _slots { get; set; } = new Dictionary<Slot, IArmor>();
		public void Add(Slot slot, IArmor slotClass)
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
