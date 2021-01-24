            int totalValues = 0;
            string[] larray = lines.ToArray(); //create array from list
            string vehicleValue;
            for (int i = 1; i < larray.Length; i++)
            {
                string[] bits = larray[i].Split(','); 
                vehicleValue = bits[4];
                int vvint = int.Parse(vehicleValue);
                totalValues = totalValues + vvint; 
            }
            totalValue.Text = totalValues.ToString(); 
