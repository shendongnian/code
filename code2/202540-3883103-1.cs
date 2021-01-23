    using namespace System;
    public ref class CSquare
    {
    private:
        double sd;
    
    public:
        CSquare() : sd(0.00) {}
        CSquare(double side) : sd(side) { }
        ~CSquare() { }
    
        property double Side
        {
    	double get() { return sd; }
    	void set(double s)
    	{
    	    if( s <= 0 )
    		sd = 0.00;
    	    else
    		sd = s;
    	}
        }
    
        property double Perimeter { double get() { return sd * 4; } }
        property double Area { double get() { return sd * sd; } }
    };
    
    array<CSquare ^> ^ CreateSquares()
    {
        array<CSquare ^> ^ sqrs = gcnew array<CSquare ^>(5);
    
        sqrs[0] = gcnew CSquare;
        sqrs[0]->Side = 5.62;
        sqrs[1] = gcnew CSquare;
        sqrs[1]->Side = 770.448;
        sqrs[2] = gcnew CSquare;
        sqrs[2]->Side = 2442.08;
        sqrs[3] = gcnew CSquare;
        sqrs[3]->Side = 82.304;
        sqrs[4] = gcnew CSquare;
        sqrs[4]->Side = 640.1115;
    
        return sqrs;
    }
