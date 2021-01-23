    template<typename TNDataType>
    class CProperty
    {
    public:
    	typedef TNDataType TDDataType;
    private:
    	TDDataType m_Value;
    public:
    	inline TDDataType& operator=(const TDDataType& Value)
    	{
    		m_Value = Value;
    		return *this;
    	}
    
    	inline operator TDDataType&()
    	{
    		return m_Value;
    	}
    };
