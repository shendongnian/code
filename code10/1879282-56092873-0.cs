    void CloseOrderWhenItIsNineAM(DateTime now)
    {
        if (now.Hour >= 9)
        {
            Order.Close();
        }
    }
