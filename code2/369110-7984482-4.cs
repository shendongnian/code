    var t1 = (int)(SomeEnum.OK | SomeEnum.Missing);       //t1 = 1 + 2 = 3
    var t2 = (int)(SomeEnum.Missing | SomeEnum.Blocking); //t2 = 2 + 4 = 6
    var t3 = (int)(SomeEnum.OK | SomeEnum.Low);           //t3 = 1 + 8 = 9
    var t4 = (int)SomeEnum.OK;                            //t4 = 1
    var s1 = (SomeEnum.Ok).ToString();                    //s1 = "Ok"
    var s2 = (SomeEnum.Ok | SomeEnum.Missing).ToString(); //s2 = "Ok, Missing"
