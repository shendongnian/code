	public static List<int> FindOnes(int number) {
		var list = new List<int>();
		var binaryString = Convert.ToString(number, 2);
		for (int i = 0 ; i < binaryString.Length ; i++) {
            if (binaryString[binaryString.Length - i - 1] == '1') {
                list.Add(i + 1);
            }
        }
		return list;
	}
    // usage:
    FindOnes(7) // [1,2,3]
