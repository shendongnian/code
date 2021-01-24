	public static void Main()
	{
		A valAsA = A.One | A.Three | A.Four;
		B valAsB = Convert<A,B>(valAsA);  // Should give me "B.Three | B.Four"
		C valAsC = Convert<A,C>(valAsA); // Should give me "C.One | C.Three"
			
		Console.WriteLine("{0} {1} {2}", valAsA, valAsB, valAsC);
	}
