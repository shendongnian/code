      ...
      // plant we are going to add
      Plant plant = new Plant(name, size, price, x, y);
      // Do we have such a plant in the list?
      if (plantsList.Any(item => item.IsClicked(x, y) == plant.IsClicked(x, y))) 
      {
          MessageBox.Show("You draw at the same position");
      } 
      else 
      {
          // if no, let's add it and compute the new lotal cost 
          plantsList.Add(plant);
          totalCost = plantsList.Sum(item => item.Price); 
      } 
      
      pictureBoxGarden.Refresh();
