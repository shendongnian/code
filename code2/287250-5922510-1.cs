    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        FieldInfo[] myFieldInfo;
        Type myType = typeof(Car);
        myFieldInfo = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        string result = @"The String fields of Car class are:";
        for (int i = 0; i < myFieldInfo.Length; i++)
        {
            if (myFieldInfo[i].FieldType == typeof(String))
            {
                result += "\r\n" + myFieldInfo[i].Name;
            }
        }
        MessageBox.Show(result);
    }
    public class Car
    {
        public string Color;
        public string Model;
        public string Made;
    }
