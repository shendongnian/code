        NOT OK Examples:
            a = Int32.Parse("a189"); //having a 
            a = Int32.Parse("1-89"); //having - but not in the beginning
            a = Int32.Parse("18 9"); //having space, but not in the beginning or end
        OK Examples:
            a = Int32.Parse("-189"); //having - but in the beginning
            a = Int32.Parse(" 189 "); //having space, but in the beginning or end
        and/or
