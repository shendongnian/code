    public BTMacResponse(WebserviceMessage w)
            {
                    // copy stuff to 'this'
            }
    
            public static implicit operator BTMacResponse(WebserviceMessage w)
            {
                    BTMacResponse b = new BTMacResponse(w);
                    return b;
            }
