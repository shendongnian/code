    public Square( int i_RowIndex, eColumn i_ColIndex) : this(i_RowIndex, i_ColIndex, eCoinType.NoCoin)
    {
    }
    
    public Square(int i_RowIndex, eColumn i_ColIndex, eCoinType i_CoinType) 
    {
                m_RowIndex = i_RowIndex;
                m_ColIndex = i_ColIndex;
                m_Coin = i_CoinType;
    }    
