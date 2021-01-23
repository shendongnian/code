        DataAccessLayer dal = new DataAccessLayer();
        DataTable movies = dal.GetMovies();
        gvMovies.DataSource = movies;
        gvMovies.AllowUserToAddRows = false;
        gvMovies.AllowUserToDeleteRows = false;
        //Create the new combobox column and set it's DataSource to a DataTable
        DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
        col.DataSource = dal.GetMovieTypes(); ; 
        col.ValueMember = "MovieTypeID";
        col.DisplayMember = "MovieType";
        col.DataPropertyName = "MovieTypeID";
        //Add your new combobox column to the gridview
        gvMovies.Columns.Add(col);
