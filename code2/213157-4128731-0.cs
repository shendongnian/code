    //set up variables
    double doubleA = Convert.ToDouble(inta);
    double doubleB = Convert.ToDouble(intb);
    double doubleC = Convert.ToDouble(intc);
    double double100 = 100.0;
    //do calculations
    double p = (doubleA / doubleB) * double100;
    double v = (p / double100) * doubleC; //why did we divide by double100 when we multiplied by it on the line above?
    return (int)v; //why are we casting back to int after all the fuss and bother with doubles?
