    void Update()
    {
        //get the input
        var input = Input.inputString;
        
        //ignore null input to avoid unnecessary computation
        if (!string.IsNullOrEmpty(input))
        {
            switch(input)
            {
                case 'a': break;
                case 'b': break;
            }
        }
    }
