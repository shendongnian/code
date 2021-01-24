       public class AsyncBoundObject
        {
        	//We expect an exception here, so tell VS to ignore
            [DebuggerHidden]
            public void Error()
            {
                throw new Exception("This is an exception coming from C#");
            }
    	
            //We expect an exception here, so tell VS to ignore
            [DebuggerHidden]
            public int Div(int divident, int divisor)
            {
                return divident / divisor;
            }
        }
    }
