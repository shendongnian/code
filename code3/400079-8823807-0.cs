    //...
    public static int TOPLEVEL_ID = 0;
    public static int PARENT_ID = 1;
    public static int SELF_ID = 2;
    public static int MENU_CAPTION = 3;
    public static int MENU_NAME = 4;
    void buttonPopMenuItemsLU_Click(object sender, RoutedEventArgs e) {
        string fileName = @"C:\_UniClientNextGen\MenuItemsWithIDs.txt";
        using(StreamReader reader = File.OpenText(fileName)) {
            string _line = null;
            string[] strElements;
            do {
                _line = reader.ReadLine();
                strElements = _line.Split(',');
                int iTopLevelID = Convert.ToInt32(strElements[TOPLEVEL_ID]);
                int iParentID = Convert.ToInt32(strElements[PARENT_ID]);
                int iOwnID = Convert.ToInt32(strElements[SELF_ID]);
                string sMenuCaption = strElements[MENU_CAPTION];
                string sMenuName = strElements[MENU_NAME];
            } while(_line != null);
        }
    }
    //...
