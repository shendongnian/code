      DateTime startDate = DateTime.Parse(sDate).Date;
      DateTime endDate = DateTime.Parse(eDate).Date;
      var missingDates = Enumerable
        .Range(0, (endDate - startDate).Days + 1)
        .Select(day => startDate.AddDays(day))
        .Where(date => !weatherList.Any(w => selected.Contains(w.City) && w.getDate != date))
        .ToArray(); // Let's materialize them as an array
      if (missingDates.Any()) {
        //TODO: we have missingDates, let user know about it
        MessageBox.Show(
          $"You have {missingDates.Length} missing dates",
           "Missing Data", 
            MessageBoxButton.OK, 
            MessageBoxImage.Warning);
      }
