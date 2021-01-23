            // Defensive database opening logic.
            if (_databaseConnection.State == ConnectionState.Broken) {
                _databaseConnection.Close();
            }
            if (_databaseConnection.State == ConnectionState.Closed) {
                _databaseConnection.Open();
            }
