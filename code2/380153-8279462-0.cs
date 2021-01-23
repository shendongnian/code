	static string ConvertBinaryToText(List<List<int>> seq){
		return new String(seq.Select(s => (char)s.Aggregate( (a,b) => a*2+b )).ToArray());
	}
    static void Main(){
       string s = "stackoverflow";
       var binary = new List<List<int>>();
       for(var counter=0; counter!=s.Length; counter++){
           List<int> a = ConvertTextToBinary(s[counter], 2);
           binary.Add(a);
           foreach(var bit in a){
               Console.Write(bit);
           }
           Console.Write("\n");
       }
       string str = ConvertBinaryToText(binary);
       Console.WriteLine(str);//stackoverflow
    }
