    Console.WriteLine("".PadRight(50, '-')); // Horizontal line to see 1st and 2nd output better
    // Now we want to play with our data, by removing the 3rd Row:
    dt.Rows.RemoveAt(2); // Index 2 is the 3rd row
    // Let's see what we got after removing:
    Console.WriteLine(dt.Columns[0].ColumnName.PadRight(20) + dt.Columns[1].ColumnName.PadRight(20)); // PadRight to make it look better..
    foreach (DataRow item in dt.Rows)
    {
        Console.WriteLine((item[0] + "").PadRight(20) + (item[1] + "").PadRight(20));
    }
