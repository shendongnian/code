    public class Calc
    {
        public Calc( Operator calcOpr, params object[] values)
        {
		switch(op)
		{
		case Op.CONCAT:
			Concat(values[0],values[1]);
		case Op.PADLEFT:
			PadLeft(values[0],values[1],values[2]);
		}
        }
        public void Concat(string str1, string str2)
        {
        }
        public void PadLeft(string str1, int startindex, int  count )
        {
        }
