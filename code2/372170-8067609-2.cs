    var stepNo = new Variable<int>("stepNo", 0);
    var activity = new Sequence
    {
        Variables = 
        {
            stepNo
        },
        Activities = 
        {
            new While
            {
                Condition = new LessThan<int,int,bool>
                {
                    Left = stepNo,
                    Right = 10
                },
    
                Body = new Sequence
                {
                    Activities = 
                    {
                        new Assign<int>
                        {
                            To = stepNo,
                            Value = new Add<int, int, int>
                            {
                                Left = stepNo,
                                Right = 1
                            }
                        },
                        new WriteLine
                        { 
                            Text = new VisualBasicValue<string>("\"Step: \" & stepNo") 
                        }
                    }
                }
            }
        }
    };
