		private static void Truncate() {
			byte[] longArray = new byte[] {1,2,3,4,5,6,7,8,9,10};
			Array.Resize(ref longArray, 5);//longArray = {1,2,3,4,5}
			//if you like linq
			byte[] shortArray = longArray.Take(5).ToArray();
		}
