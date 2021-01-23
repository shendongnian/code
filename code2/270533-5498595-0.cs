    public class Calc
    {
        public Calc( Operator calcOpr, params object[] values)
        {
		switch(op)
		{
		case Op.CONCAT:
			return Concat(values[0],values[1]);
		case Op.PADLEFT:
			return PadLeft(values[0],values[1]);
		}
        }
        public void Concat(int startindex, int  count )
        {
        }
        public void PadLeft(int startindex, int  count )
        {
        }
