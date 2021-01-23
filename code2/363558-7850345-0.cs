    public static string GetValue<T>(T obj) where T:Control
            {
                switch (obj.GetType().ToString())
                {
                    case "TextBox":
                        return (obj as TextBox).Text;
                        break;
                    case "ComboBox":
                        return (obj as ComboBox).SelectedValue.ToString();
                        break;
    
                        //..etc...
                }   
            }
