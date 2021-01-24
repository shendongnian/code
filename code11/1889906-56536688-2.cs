    public DBStatus Activate(W_Flower oFlower) {
       using (var connection = CreateDataConnection()) {
           return connection.Activate(oFlower);
       }
    }
