    Display display = new Display()
    {
      Code = item.Code,
      Name = item.Name,
      Price = item.Price,
      IdSub = Ids //if Ids is array of ints, else you need to use ToArray() method
    }
    DisplayList.Add(display);
