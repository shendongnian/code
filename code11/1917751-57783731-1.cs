    string[] parts = str.Split("-");
    string part1 = "";
    string part2 = "";
    string part3 = "";
    if(parts.Length > 4)
    {
      part1 = $"{parts[0]}-{parts[1]}-{parts[2]}";
      part2 = parts[3];
      part2 = parts[4];
    }
    else if (parts.Length > 2)
    {
      part1 = parts[0]; //Retrieves The First Part
      part2 = parts[1]; //Second Part
      part3 = parts[2]; //Third Part
    }
