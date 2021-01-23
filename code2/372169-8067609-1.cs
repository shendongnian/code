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
                Condition = new VisualBasicValue<bool>("stepNo < 10"),
    
                Body = new Sequence
                {
                    Activities = 
                    {
                        new Assign<int>
                        {
                            To = stepNo,
                            Value = new VisualBasicValue<int>("stepNo + 1")
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
