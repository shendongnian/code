    int i = 0;
    foreach (Control c in FormX.Controls)
    {
    	if (c.Name.StartsWith("textbox"))
    	{
    		array[i] = c;
    		i++;
    	}
    }
    array = array.OrderBy(a => a.Name).ToArray();
