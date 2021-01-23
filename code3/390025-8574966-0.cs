    internal static class stor
    {
        public static Outlook.Items i;
    }
    public partial class ThisAddIn
    {
        internal static Outlook.Folder posts_folder = null;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // the code for finding a posts_folder is omitted
            stor.i = posts_folder.Items;
            stor.i.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(Posts_Add);
        }
        static void Posts_Add(object Item)
        {
            System.Windows.Forms.MessageBox.Show("New item");
        }
    {
