    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() { return Name; }
    }
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecialityId { get; set; }
        public override string ToString() { return Name; }
    }
    public class CheckedListBoxItem<T>
    {
        public CheckedListBoxItem(T item)
        {
            DataBoundItem = item;
        }
        public T DataBoundItem { get; set; }
        public CheckState CheckState { get; set; }
        public override string ToString() { return DataBoundItem.ToString(); }
    }
