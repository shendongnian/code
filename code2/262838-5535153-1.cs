    private static CustomProperty GetCustomProperty(Worksheet ws, String name)
            {
                for (int i = 1; i <= ws.CustomProperties.Count; i++)
                {
                    if (ws.CustomProperties.get_Item(i).Name == name)
                        return ws.CustomProperties.get_Item(i);
                }
    
                return null;
            }
