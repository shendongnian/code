    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Remove_Click(object sender, EventArgs e)
        {
            ListBox.ObjectCollection collection = placementOneListBox.Items;
            // New collection to store our modified data
            List<string> newCollection = new List<string>();
            // We need regex to account for 0 or more spaces between items in the array.
            Regex r = new Regex(" +");
            foreach (string item in collection)
            {
                // use the regex we created to split the item into an array, it splits it based on any number of spaces.
                string[] splitItem = r.Split(item);
                // We had to write an extension method that "removes" at a particular index.
                splitItem = splitItem.RemoveAt(5);
                // Put it back together again. might have to mess with this to make it output correctly
                string updatedItem = String.Join("    ", splitItem);
                // add new item to collection
                newCollection.Add(updatedItem);
            }
            // clear the existing stuff in the listbox collection
            placementOneListBox.Items.Clear();
            // we can use a List<T> as a data source so that's what were doing here.
            placementOneListBox.DataSource = newCollection;
        }
    }
    
    public static class ExtensionMethods
    {
        // An extension method to remove an index from an array, it works with any value type
        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            if (index < 0 || index > source.Length)
                throw new IndexOutOfRangeException();
            if (source == null)
                throw new ArgumentNullException();
            T[] dest = new T[source.Length - 1];
            if (index != 0)
                Array.Copy(source, 0, dest, 0, index - 1);
            if (index != source.Length)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);
            return dest;
        }
    }
