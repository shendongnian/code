    SqlDataReader reader = cmd.ExecuteReader();
    List<MyCard> MyCardList = new List<MyCard>();
    while (reader.Read())
    {
         MyCard mycard = new MyCard();
         mycard.Name = reader[0].ToString();
         mycard.Number = reader[1].ToString();
         mycard.Expiry = reader[2].ToString();
         mycard.Balance = reader[3].ToString();
         MyCardList.Add(mycard);
    }
    //Remember to close the reader and dispose of objects correctly.
