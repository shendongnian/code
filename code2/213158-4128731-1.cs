    //set up variables
    double doubleA = Convert.ToDouble(inta);
    double doubleB = Convert.ToDouble(intb);
    double doubleC = Convert.ToDouble(intc);
    //do calculations
    double p = (doubleA / doubleB) * 100
    double v = (p / 100) * doubleC; //why did we divide by 100 when we multiplied by it on the line above?
    return (int)v; //why are we casting back to int after all the fuss and bother with doubles?
