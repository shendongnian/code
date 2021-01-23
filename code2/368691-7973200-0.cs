    while(!SomeQueue.Empty)
    {
		byte nextByte = SomeQueue.Dequeue();
		switch State:
		{
			case A:
				if(nextByte == Condition)
				{
					State = B;
				}
				else				
				{
					State = ParseError;
				}
				continue;
			case B:
				//Test nextByte
				State = C;
				continue;
			case C:
				//Test nextByte
				State = A;
				continue;
			case ParseError:
				//Do something for this condition
				State = A;
				continue;
    }
