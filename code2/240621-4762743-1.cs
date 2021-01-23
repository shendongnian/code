        public void setMovieName(Movie movie, string newName)
        {
            Console.WriteLine("CurrentName: " + movie.Name);
            movie.Name = newName; //The notification is now raised automatically in the setter of the property in the movie class
            Console.WriteLine("NewName: " + movie.Name);
        }
