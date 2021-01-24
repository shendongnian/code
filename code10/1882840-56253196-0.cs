    List<EmployeeViewModel> EmployeeVM = new List<EmployeeViewModel>
    
    foreach(var movie in movies)
    {
      var temp =     new EmployeeViewModel {
            MovieID = movie.MovieID,
            MovieName = movie.MovieName,
            MovieDescription = movie.MovieDescription,
            MoviePrice = movie.MoviePrice,
            MovieCategory = movie.MovieCategory,
            MovieYear = movie.MovieYear
        };
    
    EmployeeVM.Add(temp);
    }
