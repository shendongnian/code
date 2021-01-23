    enum E
    {
    	A = 1,   /* index 0 */
    	B = 2,   /* index 1 */
    	C = 4,   /* index 2 */
    	D = 4    /* index 3, duplicate use of 4 */
    }
    
    void Main()
    {
    	E e = E.C;
    	int index = Array.IndexOf(Enum.GetValues(e.GetType()), e);
    	// index is 2
    	
    	E f = (E)(Enum.GetValues(e.GetType())).GetValue(index);
    	// f is  E.C
    }
