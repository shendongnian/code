    int totalValues = 0;
    
    string[] larray = lines.ToArray(); //create array from list
    string vehicleValue;
    
    for (int i = 0; i < larray.Length; i++)
    {
        string[] bits = larray[i].Split(','); 
        vehicleValue = bits[3];
        int vvint = int.Parse(bits[3]);
        totalValues = totalValues + vvint; 
    }
    totalValue.Text = totalValues.ToString(); 
