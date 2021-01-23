    <DataTemplate>
        <TextBlock Text="{Binding}"/>
    </DataTemplate>
    public class Person
    {
        public override string ToString()
        {
            return String.Format("{0} | {1}", Name, ID);
        }
        public string Name { get; set; }
        public int ID { get; set; }
    }
