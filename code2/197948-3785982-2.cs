    int i = 0;
    foreach (Control c in FormX.Controls)
    {
    	if (c.Name.StartsWith("textbox"))
    	{
    		array[i] = c;
    		i++;
    	}
    }
    array = array.OrderBy(a => Convert.ToInt32(a.Name.Substring(7))).ToArray();
